import * as request from './requester.js'

const baseUrl = 'http://localhost:3030/data/posts';

export const getAll = () => request.get(`${baseUrl}?sortBy=_createdOn%20desc`);

export const getOne = (postId) => request.get(`${baseUrl}/${postId}`);

export const getAllForUser = (userId) => request.get(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);

export const create = (postData) => request.post(baseUrl, postData);

export const edit = (postId, postData) => request.put(`${baseUrl}/${postId}`, postData);

export const del = (postId) => request.del(`${baseUrl}/${postId}`);

export const donate = (postId) => {
    return request.post('http://localhost:3030/data/donations', {
        postId
    });
}

export const getDonationsByPost = (postId) => {
    return request.get(`http://localhost:3030/data/donations?where=postId%3D%22${postId}%22&distinct=_ownerId&count`);
}

export const getMyDonationByPostId = (postId, userId) => {
 return request.get(`http://localhost:3030/data/donations?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
}

window.donate = donate;
window.getDonationsByPost = getDonationsByPost;
window.getMyDonationByPostId = getMyDonationByPostId;