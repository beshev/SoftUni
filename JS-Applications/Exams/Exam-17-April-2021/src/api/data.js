import createApi from './api.js'

const endpoints = {
    RESOURCES: 'data/pets',
    RESOURCE_BY_Id: 'data/pets/',
    PETS_CATALOG: 'data/pets?sortBy=_createdOn%20desc',
    MY_PETS: (userId) => `data/pets?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    LIKES: 'data/likes',
    GET_PET_LIKES: (petId) => `data/likes?where=petId%3D%22${petId}%22&distinct=_ownerId&count`,
    GET_USER_LIKES_FOR_PET: (petId, userId) => `data/likes?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`
}

const api = createApi();

export const loginAsync = api.loginAsync.bind(api);
export const registerAsync = api.registerAsync.bind(api);
export const logoutAsync = api.logoutAsync.bind(api);

export async function getResourceByIdAsync(id) {
    return await api.getAsync(endpoints.RESOURCE_BY_Id + id);
}

export async function getMyPets(userId) {
    return await api.getAsync(endpoints.MY_PETS(userId));
}

export async function getUserLikesForPet(petId, userId) {
    return await api.getAsync(endpoints.GET_USER_LIKES_FOR_PET(petId, userId));
}

export async function getPetLikes(petId) {
    return await api.getAsync(endpoints.GET_PET_LIKES(petId));
}

export async function getAllResourcesAsync() {
    return await api.getAsync(endpoints.PETS_CATALOG);
}

export async function editResourceByIdAsync(id, body) {
    return await api.putAsync(endpoints.RESOURCE_BY_Id + id, body)
}

export async function createResourceAsync(body) {
    return await api.postAsync(endpoints.RESOURCES, body);
}

export async function sendLike(petId) {
    return await api.postAsync(endpoints.LIKES, petId);
}

export async function deleteResourceByIdAsync(id) {
    return await api.deleteAsync(endpoints.RESOURCE_BY_Id + id)
}