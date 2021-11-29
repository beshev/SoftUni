import createApi from './api.js'

const endpoints = {
    RESOURCES: 'data/wiki',
    ARTICLES: 'data/wiki?sortBy=_createdOn%20desc',
    RESOURCE_BY_Id: 'data/wiki/',
    ARTICLE_BY_CATEGORY: 'data/wiki?sortBy=_createdOn%20desc&distinct=category',
    SEARCH_BY_TITLE: (query) => `data/wiki?where=title%20LIKE%20%22${query}%22`
}

const api = createApi();

export const loginAsync = api.loginAsync.bind(api);
export const registerAsync = api.registerAsync.bind(api);
export const logoutAsync = api.logoutAsync.bind(api);

export async function getResourceByIdAsync(id) {
    return api.getAsync(endpoints.RESOURCE_BY_Id + id);
}

export async function getAllResourcesAsync() {
    return api.getAsync(endpoints.ARTICLES);
}

export async function getByTitle(title) {
    return api.getAsync(endpoints.SEARCH_BY_TITLE(title));
}

export async function getArticleByCategory() {
    return api.getAsync(endpoints.ARTICLE_BY_CATEGORY);
}

export async function editResourceByIdAsync(id, body) {
    return api.putAsync(endpoints.RESOURCE_BY_Id + id, body)
}

export async function createResourceAsync(body) {
    return api.postAsync(endpoints.RESOURCES, body);
}

export async function deleteResourceByIdAsync(id) {
    return api.deleteAsync(endpoints.RESOURCE_BY_Id + id)
}