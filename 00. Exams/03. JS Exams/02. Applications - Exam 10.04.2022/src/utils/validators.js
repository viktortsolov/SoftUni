export const postIsInvalid = (postData) => {
    const requiredFields = [
        'title',
        'description',
        'imageUrl',
        'address',
        'phone'
    ];

    return requiredFields.some(x => !postData[x]);
};