//@ts-check
const { chromium } = require('playwright-chromium');
const { expect, assert } = require('chai');


let browser;
let context;
let page;

describe('E2E tests', function () {
    this.timeout(6000);

    before(async () => {
        browser = await chromium.launch({ headless: false, slowMo: 200 });
        // browser = await chromium.launch();
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();

        // block intensive resources and external calls (page routes take precedence)
        await context.route('**/*.{png,jpg,jpeg}', route => route.abort());
        await context.route(url => {
            return url.hostname != 'localhost';
        }, route => route.abort());

        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    describe('Catalog', () => {
        // it('should load and render the content of the API', async () => {
        //     await page.goto('http://localhost:3000/2.My-Cookbook/index.html');
        //     let recipes = await page.$$eval('article.preview h2', r => r.map(s => s.textContent));

        //     assert.equal(recipes[0], 'Easy Lasagna');
        //     assert.equal(recipes[1], 'Grilled Duck Fillet');
        //     assert.equal(recipes[2], 'Roast Trout');
        // })

        // it('displays recipe details', async () => {
        //     await page.goto('http://localhost:3000/2.My-Cookbook/index.html');
        //     let recipe = await page.$('article.preview');
        //     await recipe.click();

        //     let content = await page.textContent('article');

        //     expect(content).to.contain('Easy Lasagna');

        //     expect(content).to.contain('Ingredients:');
        //     expect(content).to.contain('1 tbsp Ingredient 1');

        //     expect(content).to.contain('Preparation:');
        //     expect(content).to.contain('Prepare ingredients');
        //     expect(content).to.contain('Mix ingredients');
        //     expect(content).to.contain('Cook until done');
        // })
    })

    describe('Authentication', () => {
        // it('login should work', async () => {
        //     let email = 'peter@abv.bg';
        //     let password = '123456'

        //     await page.goto('http://localhost:3000/2.My-Cookbook/index.html');
        //     await page.click('text=Login');

        //     await page.waitForSelector('form');

        //     await page.fill('input[name=email]', email);
        //     await page.fill('input[name=password]', password);

        //     let [response] = await Promise.all([
        //         page.waitForResponse('**/users/login'),
        //         page.click('[type="submit"]')
        //     ])

        //     let data = JSON.parse(response.request().postData());

        //     assert.equal(data.email,email);
        //     assert.equal(data.password,password);
        // })

        // it('register should work', async () => {
        //     let email = 'peter@abv.bg';
        //     let password = '123456';
        //     let rePass = '123456';

        //     await page.goto('http://localhost:3000/2.My-Cookbook/index.html');
        //     await page.click('text=Register');

        //     await page.waitForSelector('form');

        //     await page.fill('[name=email]', email);
        //     await page.fill('[name=password]', password);
        //     await page.fill('[name=rePass]', rePass);

        //     let [response] = await Promise.all([
        //         page.waitForResponse('**/users/register'),
        //         page.click('[type="submit"]')
        //     ])

        //     let data = JSON.parse(response.request().postData());

        //     assert.equal(data.email, email);
        //     assert.equal(data.password, password);
        // })
    })

    describe('CRUD operations', () => {
        /* Login user */
        beforeEach(async () => {
            // Login
            let email = 'peter@abv.bg';
            let password = '123456'
            await page.goto('http://localhost:3000/2.My-Cookbook/index.html');
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.fill('input[name=email]', email);
            await page.fill('input[name=password]', password);

            await Promise.all([
                page.waitForResponse('**/users/login'),
                page.click('[type="submit"]')
            ]);
        });

        it('create makes correct API call for logged in user', async () => {
            // Creating recipe
            let img = 'http://www.supichka.com/files/images/1344/fit_1400_933.jpg';
            let name = 'Mакарони на Фурна';
            let ingredients = 'Ing 1\nIng 2\nIng 3';
            let steps = 'Step 1\nStep 2\nStep 3';

            await page.click('text=Create Recipe')
            await page.waitForSelector('form');
            await page.fill('[name=name]', name);
            await page.fill('[name=img]', img);
            await page.fill('[name=ingredients]', ingredients);
            await page.fill('[name=steps]', steps);

            let [response] = await Promise.all([
                page.waitForResponse('**/data/recipes'),
                page.click('[type="submit"]')
            ])

            let data = JSON.parse(response.request().postData());

            assert.equal(data.name, name);
            assert.equal(data.img, img);
            assert.deepEqual(data.ingredients.join('\n'), ingredients);
            assert.deepEqual(data.steps.join('\n'), steps);

        })

        it('The author can see the "Edit" and "Delete" button', async () => {
            await page.click('text=Mакарони на Фурна');

            let buttons = await page.$$('button');
            assert.equal(await buttons[0].textContent(), '✎ Edit');
            assert.equal(await buttons[1].textContent(), '✖ Delete');
        })

        it('edit loads the correct article data for logged in user', async () => {
            await page.click('text=Mакарони на Фурна');
            await page.click('text=Edit');
            await page.waitForSelector('form');

            assert.equal(await page.inputValue('[name=name]'),'Mакарони на Фурна');
            assert.equal(await page.inputValue('[name=img]'),'http://www.supichka.com/files/images/1344/fit_1400_933.jpg');
            assert.equal(await page.inputValue('[name=ingredients]'),'Ing 1\nIng 2\nIng 3');
            assert.equal(await page.inputValue('[name=steps]'),'Step 1\nStep 2\nStep 3');
        })

        it('edit makes correct API call for logged in user', async () => {
            await page.click('text=Mакарони на Фурна');
            await page.click('text=Edit');
            await page.waitForSelector('form');

            let newName = 'Mакарони без Фурна'
            await page.fill('[name=name]', newName);

            let newIng = 'I1\nI2\nI3';
            await page.fill('[name=ingredients]', newIng);

            let [response] = await Promise.all([
                page.waitForResponse('**/recipes/5542e0e3-cf8b-4c96-a239-8fc7894dc3ee'),
                page.click('[type="submit"]'),
            ]);

            let data = JSON.parse(response.request().postData());

            assert.equal(data.name,newName);
            assert.deepEqual(data.ingredients,newIng.split('\n'));
        })

        it('delete makes correct API call for logged in user', async () => {
            await page.click('text=Mакарони на Фурна');
            await page.click('text=Delete');
            await page.waitForSelector('article');

            page.on('dialog', dialog => dialog.accept());

            const [request] = await Promise.all([
                page.waitForRequest('**/recipes/e9843719-fa90-464a-9690-fda60b4d75b2'),
                page.click('button:text("Delete")')
            ]);

            assert.equal(request.method(),'DELETE');
        })
    });

});
