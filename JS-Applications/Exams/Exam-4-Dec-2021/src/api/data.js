import createApi from './api.js'

const endpoints = {
    ALBUMS: 'data/albums?sortBy=_createdOn%20desc&distinct=name',
    RESOURCES: 'data/albums',
    RESOURCE_BY_Id: 'data/albums/',
    SEARCH: (query) => `data/albums?where=name%20LIKE%20%22${query}%22`,
}

const api = createApi();

export const loginAsync = api.loginAsync.bind(api);
export const registerAsync = api.registerAsync.bind(api);
export const logoutAsync = api.logoutAsync.bind(api);

export async function getResourceByIdAsync(id) {
    return await api.getAsync(endpoints.RESOURCE_BY_Id + id);
}

export async function getAllResourcesAsync() {
    return await api.getAsync(endpoints.ALBUMS);
}

export async function searchAlbum(query) {
    return await api.getAsync(endpoints.SEARCH(query));
}

export async function editResourceByIdAsync(id, body) {
    return await api.putAsync(endpoints.RESOURCE_BY_Id + id, body)
}

export async function createResourceAsync(body) {
    return await api.postAsync(endpoints.RESOURCES,body);
}

export async function deleteResourceByIdAsync(id) {
    return await api.deleteAsync(endpoints.RESOURCE_BY_Id + id)
}