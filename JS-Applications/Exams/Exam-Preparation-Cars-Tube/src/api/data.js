import createApi from './api.js'

const endpoints = {
    RESOURCES: 'data/cars?sortBy=_createdOn%20desc',
    RESOURCE_BY_Id: 'data/cars/',
    CREATE_RESOURCES: 'data/cars',
    MY_RESOURCES: (userId) => `data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    SEARCH: (year) => `data/cars?where=year%3D${year}` 
}

const api = createApi();

export const loginAsync = api.loginAsync.bind(api);
export const registerAsync = api.registerAsync.bind(api);
export const logoutAsync = api.logoutAsync.bind(api);

export async function getResourceByIdAsync(id) {
    return await api.getAsync(endpoints.RESOURCE_BY_Id + id);
}

export async function searchCar(year) {
    return await api.getAsync(endpoints.SEARCH(year));
}

export async function getMyCars(userId) {
    return await api.getAsync(endpoints.MY_RESOURCES(userId));
}

export async function getAllResourcesAsync() {
    return await api.getAsync(endpoints.RESOURCES);
}

export async function editResourceByIdAsync(id, body) {
    return await api.putAsync(endpoints.RESOURCE_BY_Id + id, body)
}

export async function createResourceAsync(body) {
    return await api.postAsync(endpoints.CREATE_RESOURCES, body);
}

export async function deleteResourceByIdAsync(id) {
    return await api.deleteAsync(endpoints.RESOURCE_BY_Id + id)
}