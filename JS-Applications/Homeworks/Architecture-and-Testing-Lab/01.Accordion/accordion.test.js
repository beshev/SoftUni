const { chromium } = require('playwright-chromium');

const { assert } = require('chai');

let browser, page; // Declare reusable variables

describe('E2E tests', function () {
    //this.timeout(2000);

    before(async () => {
        // browser = await chromium.launch({ headless: false, slowMo: 500 });
        browser = await chromium.launch();
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        await page.close();
    });

    describe('Accordion tests', async () => {
        it('Load titles', async () => {
            await page.goto('http://localhost:3000/01.Accordion/index.html');

            let titles = await page.$$('#main span');

            assert.equal(await titles[0].textContent(), 'Scalable Vector Graphics');
            assert.equal(await titles[1].textContent(), 'Open standard');
            assert.equal(await titles[2].textContent(), 'Unix');
            assert.equal(await titles[3].textContent(), 'ALGOL');
        })

        it('button click should load content and change from MORE to LESS', async () => {
            await page.goto('http://localhost:3000/01.Accordion/index.html');
            let button = await page.$('#main .accordion button');
            await button.click();

            let accordionP = await page.$('#main .accordion div p');

            let expected = `Scalable Vector Graphics (SVG) is an Extensible Markup Language (XML)-based vector image format for two-dimensional graphics with support for interactivity and animation. The SVG specification is an open standard developed by the World Wide Web Consortium (W3C) since 1999.`

            let actual = await accordionP.textContent();

            assert.equal(actual, expected);
            assert.equal(await button.textContent(), 'Less');

        })

        it('clicking the button twice should hide the content', async () => {
            await page.goto('http://localhost:3000/01.Accordion/index.html');
            let button = await page.$('#main .accordion button');
            await button.click();
            await button.click();

            let isVisible = await page.isVisible('.extra');

            assert.isFalse(isVisible);
            assert.equal(await button.textContent(), 'More');
        })
    })

});