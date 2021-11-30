import { deleteResourceByIdAsync, getPetLikes, getResourceByIdAsync, getUserLikesForPet, sendLike } from "../api/data.js";
import authService from "../authService.js";
import { html } from "../lib.js";


const detailsTemplate = (pet, petLikes, isUserLikePet, isOwner, isUser , onDelete, onLike) => html`
<section id="details-page" class="details">
    <div class="pet-information">
        <h3>Name: ${pet.name}</h3>
        <p class="type">Type: ${pet.type}</p>
        <p class="img"><img src=${pet.imageUrl}></p>
        <div class="actions">
            ${isOwner 
                ? html`
                <a class="button" href="/edit/${pet._id}">Edit</a>
                <a class="button" href="javascript:void(0)" @click=${onDelete}>Delete</a>`
                : null}

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current pet ) -->
            ${isUser && !isUserLikePet ? html`<a class="button" href="javascript:void(0)" @click=${onLike}>Like</a>` : null}
            

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${petLikes}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="pet-description">
        <h3>Description:</h3>
        <p>${pet.description}</p>
    </div>
</section>
`;


export function setupDetails() {
    return showDetails;

    async function showDetails(context) {
        const petId = context.params.id;
        const userId = authService.getUserId();
        let userLikesCount = 0;

        if (userId !== null) {
            userLikesCount = await getUserLikesForPet(petId, userId);
        }

        const [petLikes, pet] = await Promise.all([
            getPetLikes(petId),
            getResourceByIdAsync(petId),
        ]);
        

        const isOwner = userId === pet._ownerId;
        const isUser = !isOwner && userId !== null;
        const isUserLikePet = userLikesCount > 0;

        return detailsTemplate(pet, petLikes, isUserLikePet, isOwner, isUser, onDelete, onLike);

        async function onDelete() {
            try {
                const confirm = window.confirm("Are you sure you wanna DELETE this pet?!");

                if (confirm) {
                    await deleteResourceByIdAsync(petId);
                    context.page.redirect('/');
                }
                
            } catch (err) {
                alert(err.message);
            }
        }

        async function onLike() {
            await sendLike({petId: petId});
            context.page.redirect(`/details/${petId}`);
        }
        
    }
}