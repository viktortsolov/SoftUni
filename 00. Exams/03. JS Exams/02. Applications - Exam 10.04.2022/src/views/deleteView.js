import * as postService from '../services/postService.js'

export const deleteView = async (ctx) => {
    const postId = ctx.params.postId;

    postService.getOne(postId)
        .then(post => {
            if (post._ownerId != ctx.user._id) {
                ctx.page.redirect(`/posts/${post._id}`);

                throw 'Post ownership failed!';
            }

            return postService.del(postId);
        })
        .then(() => ctx.page.redirect('/'))
        .done();
};