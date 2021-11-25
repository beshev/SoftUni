import createApi from './api.js'

const endpoints = {
    RESOURCES_ALL: 'data/books?sortBy=_createdOn%20desc',
    RESOURCE_BY_Id: 'data/books/',
    RESOURCES: 'data/books',
    MY_BOOKS: (userId) => `data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    LIKES: 'data/likes',
    LIKES_COUNT: (bookId) => `data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`,
    OWN_LIKES: (bookId, userId) => `data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`
}

const api = createApi();

export const loginAsync = api.loginAsync.bind(api);
export const registerAsync = api.registerAsync.bind(api);
export const logoutAsync = api.logoutAsync.bind(api);

export async function getResourceByIdAsync(id) {
    return await api.getAsync(endpoints.RESOURCE_BY_Id + id);
}

export async function sendLikeToBook(bookId) {
    return await api.postAsync(endpoints.LIKES, { bookId: bookId });
}

export async function getUserLikesForBook(bookId, userId) {
    return await api.getAsync(endpoints.OWN_LIKES(bookId, userId));
}

export async function getBookLikes(bookId) {
    return await api.getAsync(endpoints.LIKES_COUNT(bookId));
}

export async function getAllResourcesAsync() {
    return await api.getAsync(endpoints.RESOURCES_ALL);
}

export async function editResourceByIdAsync(id, body) {
    return await api.putAsync(endpoints.RESOURCE_BY_Id + id, body)
}

export async function createResourceAsync(body) {
    return await api.postAsync(endpoints.RESOURCES, body);
}

export async function getMyBooks(userId) {
    return await api.getAsync(endpoints.MY_BOOKS(userId));
}

export async function deleteResourceByIdAsync(id) {
    return await api.deleteAsync(endpoints.RESOURCE_BY_Id + id)
}