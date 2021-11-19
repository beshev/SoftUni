import { html } from "../lib.js";
import auth from '../auth.js'


const profileTemplate = (user) => html`
<!-- Profile Page ( Only for logged users ) -->
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/${user.isMale ? 'male' : 'female'}.png">
        <div class="user-content">
            <p>Username: ${user.username}</p>
            <p>Email: ${user.email}</p>
            <p>My memes count: ${user.memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        <!-- Display : All created memes by this user (If any) -->
        ${user.memes.length > 0 ? user.memes.map(memeTemplate) : html`<p class="no-memes">No memes in database.</p>`}
        <!-- Display : If user doesn't have own memes  -->
    </div>
</section>
`;

const memeTemplate = (meme) => html`
    <div class="user-meme">
        <p class="user-meme-title">${meme.title}</p>
        <img class="userProfileImage" alt="meme-img" src=${meme.imageUrl}>
        <a class="button" href="/details/${meme._id}">Details</a>
    </div>
`


export function setupProfile() {
    return showProfile;

    async function showProfile() {
        const userId = auth.getUserId();
        const userMemes = await (await fetch(`http://localhost:3030/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)).json();

        const user = {
            email: auth.getUserEmail(),
            username: auth.getUsername(),
            memes: userMemes,
            isMale: auth.getGender() == 'male'
        }

        return profileTemplate(user);
    }
}