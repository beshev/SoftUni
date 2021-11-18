import { html } from "../dom.js"

const homeTemplate = (isAuth) => html`
    <section id="home">
        <article class="hero layout">
            <img src="./assets/team.png" class="left-col pad-med">
            <div class="pad-med tm-hero-col">
                <h2>Welcome to Team Manager!</h2>
                <p>Want to organize your peers? Create and manage a team for free.</p>
                <p>Looking for a team to join? Browse our communities and find like-minded people!</p>
                ${!isAuth ? html`<a href="/register" class="action cta">Sign Up Now</a>` 
                : html`<a href="/browse-teams" class="action cta">Browse Teams</a>`}
            </div>
        </article>
    </section>
`


export function setupHome() {
    return showHome

    async function showHome() {
        const isAuth = sessionStorage.getItem('token') !== null;

        return homeTemplate(isAuth);
    }
}