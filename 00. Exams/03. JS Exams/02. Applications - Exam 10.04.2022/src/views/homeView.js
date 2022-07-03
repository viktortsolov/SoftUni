import { html } from '../../node_modules/lit-html/lit-html.js';
import * as postService from '../services/postService.js';

const homeTemplate = (posts) => html`
            <section id="dashboard-page">
                <h1 class="title">All Posts</h1>

                <div class="all-posts">
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
                ${posts.length == 0 ? html`<h1 class="title no-posts-title">No posts yet!</h1>` : ``}
            </section>
            `;

export const homeView = (ctx) => {
    postService.getAll()
        .then(posts => {
            ctx.render(homeTemplate(posts))
        });
}