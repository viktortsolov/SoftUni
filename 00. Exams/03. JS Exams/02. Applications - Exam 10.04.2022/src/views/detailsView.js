import { html } from '../../node_modules/lit-html/lit-html.js';
import * as postService from '../services/postService.js';

const detailsTemplate = (post, isOwner, donates, showDonateButton) => html`
<section id="details-page">
<h1 class="title">Post Details</h1>

<div id="container">
    <div id="details">
        <div class="image-wrapper">
            <img src="${post.imageUrl}" alt="Material Image" class="post-image">
        </div>
        <div class="info">
            <h2 class="title post-title">${post.title}</h2>
            <p class="post-description">Description: ${post.description}</p>
            <p class="post-address">Address: ${post.address}</p>
            <p class="post-number">Phone number: ${post.phone}</p>
            <p class="donate-Item">Donate Materials: ${donates}</p>

            
            <div class="btns">
                ${isOwner
        ? html`
                        <a href="/posts/${post._id}/edit" class="edit-btn btn">Edit</a>
                        <a href="/posts/${post._id}/delete" class="delete-btn btn">Delete</a>`
        : ``
    }

                ${donationControlesTemplates(showDonateButton, post._id)}
            </div>
        </div>
    </div>
</div>
</section>`;

export const detailsView = async (ctx) => {
    let donations = await postService.getDonationsByPost(ctx.params.postId);
    let hasDonation = ctx.user ? await postService.getMyDonationByPostId(ctx.params.postId, ctx.user._id) : 0;

    postService.getOne(ctx.params.postId)
        .then(post => {
            if (ctx.user) {
                let isOwner = ctx.user._id == post._ownerId;

                let showDonateButton = true;

                if (isOwner) {
                    showDonateButton = false;
                }

                if (hasDonation == 1) {
                    showDonateButton == false;
                }

                ctx.render(detailsTemplate(post, isOwner, donations, showDonateButton))
            } else {
                ctx.render(detailsTemplate(post, false, donations, false))
            }
        });
}

function donationControlesTemplates(showDonateButton, postId) {
    if (!showDonateButton) {
        return null;
    } else {
        return html`<a @click=${onDonate(postId)} href="javascript: void(0)" class="donate-btn btn">Donate</a>`
    }
}

function onDonate(postId) {
    postService.donate(postId);
}