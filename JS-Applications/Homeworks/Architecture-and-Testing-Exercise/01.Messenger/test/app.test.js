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
        await page.goto('http://localhost:3000');
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });


    describe('Messenger–Testing', () => {
        describe('load messages', () => {
            it('should show all messages when the refresh button is clicked', async () => {
                await page.click('id=refresh');

                let expect = `Spami: Hello, are you there?
Garry: Yep, whats up :?
Spami: How are you? Long time no see? :)
George: Hello, guys! :))
Spami: Hello, George nice to see you! :)))`

                let actual = await page.inputValue('id=messages');

                assert.include(actual, expect)
            })
        })

        describe('send message', () => {
            it('should send message to server', async () => {
                let author = 'Gogo(malkiq)';
                let content = 'Go, go, power rangers';

                await page.fill('[id=author]', author);
                await page.fill('[id=content]', content);

                let [response] = await Promise.all([
                    page.waitForResponse('**/jsonstore/messenger'),
                    page.click('[id=submit]'),
                ])

                let data = JSON.parse(response.request().postData());

                assert.equal(data.author, author);
                assert.equal(data.content, content);
            })
        })
    })
});
