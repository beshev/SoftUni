//@ts-check
const { chromium } = require('playwright-chromium');
const { expect, assert } = require('chai');


let browser;
let context;
let page;

describe('E2E tests', function () {
    this.timeout(6000);

    before(async () => {
        browser = await chromium.launch({ headless: false, slowMo: 600 });
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
        await page.goto('http://localhost:3000/02.Book-Library/index.html');
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });


    describe('Book-Library–Testing', () => {
        it('load books', async () => {
            await page.click('#loadBooks');

            let rows = await page.$$eval('td', td => td.map(x => x.textContent.trim()));
            let actual = rows.join('\n');

            assert.include(actual, 'Harry Potter and the Philosopher\'s Stone');
            assert.include(actual, 'J.K.Rowling');
            assert.include(actual, 'Edit');
            assert.include(actual, 'Delete');
            assert.include(actual, 'C# Fundamentals');
            assert.include(actual, 'Svetlin Nakov');
            assert.include(actual, 'Edit');
            assert.include(actual, 'Delete');

        })

        it('add book validation of the input fields should work', async () => {
            let createButton = await page.$('#createForm button');
            page.on('dialog', (d) => {
                assert.equal('All fields are required!', d.message());
                d.accept();
            });

            await createButton.click();
        })

        it('add book should work', async () => {
            let author = 'Malkiq Gogo';
            let title = 'Never grow up :)'

            await page.fill('#createForm [name=author]', author);
            await page.fill('#createForm [name=title]', title);

            let createButton = await page.$('#createForm button');

            let [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                createButton.click()
            ]);

            let data = JSON.parse(response.request().postData());

            assert.equal(data.author, author);
            assert.equal(data.title, title);
        })

        it('edit book should load currect data', async () => {
            await page.click('#loadBooks');
            let firstTr = await page.$('tbody tr');

            let title = await firstTr.$('td:nth-child(1)');
            title = await title.textContent();

            let author = await firstTr.$('td:nth-child(2)');
            author = await author.textContent();

            await page.click('td button');

            let actualTitle = await page.inputValue('#editForm input[name="title"]');
            let actualAuthor = await page.inputValue('#editForm input[name="author"]');

            assert.equal(actualTitle, title);
            assert.equal(actualAuthor, author);
            assert.isTrue(await page.isVisible('#editForm'));
            assert.isFalse(await page.isVisible('#createForm'));
        })

        it('edit book should work', async () => {
            await page.click('#loadBooks');

            await page.click('td button');

            let newAuthor = 'J.K.Rowling Limited Edition';
            let newTitle = 'Harry Potter and the Philosopher\'s Stone Limited Edition';

            await page.fill('#editForm [name="title"]', newTitle);
            await page.fill('#editForm [name="author"]', newAuthor);

            let [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books/d953e5fb-a585-4d6b-92d3-ee90697398a0'),
                page.click('#editForm button'),
            ]);

            let data = JSON.parse(response.request().postData());

            assert.equal(data.author, newAuthor);
            assert.equal(data.title, newTitle);
            assert.isFalse(await page.isVisible('#editForm'));
            assert.isTrue(await page.isVisible('#createForm'));
        })

        it('delete book', async () => {
            await page.click('#loadBooks');

            page.on('dialog', (d) => {
                assert.equal('Are you sure you want to delete this book?', d.message());
                d.accept();
            });

            let content = await page.textContent('tbody');

            assert.notInclude('J.K.Rowling', content);
            assert.notInclude('Harry Potter and the Philosopher\'s Stone', content);
        })
    })
});
