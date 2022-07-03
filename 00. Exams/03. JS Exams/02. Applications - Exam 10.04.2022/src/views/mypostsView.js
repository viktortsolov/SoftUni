import { html } from '../../node_modules/lit-html/lit-html.js';
import * as postService from '../services/postService.js';

const myPostTemplate = (posts) => html`
    <section id="my-posts-page">
        <h1 class="title">My Posts</h1>

        <!-- Display a div with information about every post (if any)-->
        <div class="my-posts">

            ${posts.map(x => html`
            <div class="post">
                <h2 class="post-title">${x.title}</h2>
                <img class="post-image" src="${x.imageUrl}" alt="Material Image">
                <div class="btn-wrapper">
                    <a href="/posts/${x._id}" class="details-btn btn">Details</a>
                </div>
            </div>
            `)}

        </div>

        ${posts.length == 0 ? html`<h1 class="title no-posts-title">You have no posts yet!</h1>` : ``}
    </section>
            `;

export const myPostView = (ctx) => {
    postService.getAllForUser(ctx.user._id)
        .then(posts => {
            ctx.render(myPostTemplate(posts))
        })
}