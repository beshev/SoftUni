import createApi from './api.js'

const endpoints = {
    RESOURCES: 'data/games?sortBy=_createdOn%20desc',
    GAMES: 'data/games',
    RESOURCE_BY_Id: 'data/games/',
    THREE_MOST: 'data/games?sortBy=_createdOn%20desc&distinct=category',
    COMMENTS_FOR_GAME: (gameId) => `data/comments?where=gameId%3D%22${gameId}%22`,
    ADD_COMMENT: 'data/comments',
}

const api = createApi();

export const loginAsync = api.loginAsync.bind(api);
export const registerAsync = api.registerAsync.bind(api);
export const logoutAsync = api.logoutAsync.bind(api);

export async function getResourceByIdAsync(id) {
    return await api.getAsync(endpoints.RESOURCE_BY_Id + id);
}

export async function getCommentsForGame(id) {
    return await api.getAsync(endpoints.COMMENTS_FOR_GAME(id));
}

export async function getThreeMostGames() {
    return await api.getAsync(endpoints.THREE_MOST);
}

export async function getAllResourcesAsync() {
    return await api.getAsync(endpoints.RESOURCES);
}

export async function editResourceByIdAsync(id, body) {
    return await api.putAsync(endpoints.RESOURCE_BY_Id + id, body)
}

export async function addComment(body) {
    return await api.postAsync(endpoints.ADD_COMMENT, body)
}

export async function createResourceAsync(body) {
    return await api.postAsync(endpoints.GAMES, body);
}

export async function deleteResourceByIdAsync(id) {
    return await api.deleteAsync(endpoints.RESOURCE_BY_Id + id)
}