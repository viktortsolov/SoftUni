import { html } from '../../node_modules/lit-html/lit-html.js';
import * as userService from '../services/userService.js';

const registerTemplate = (submitHandler) => html`
        <section id="register-page" class="auth">
            <form @submit=${submitHandler} id="register">
                <h1 class="title">Register</h1>

                <article class="input-group">
                    <label for="register-email">Email: </label>
                    <input type="email" id="register-email" name="email">
                </article>

                <article class="input-group">
                    <label for="register-password">Password: </label>
                    <input type="password" id="register-password" name="password">
                </article>

                <article class="input-group">
                    <label for="repeat-password">Repeat Password: </label>
                    <input type="password" id="repeat-password" name="repeatPassword">
                </article>

                <input type="submit" class="btn submit-btn" value="Register">
            </form>
        </section>
        `

const registerIsInvalid = (registerData) => {
    const requiredFields = [
        'email',
        'password',
        'repeatPassword'
    ];

    return requiredFields.some(x => !registerData[x]);
};

export const registerView = (ctx) => {
    const submitHandler = (e) => {
        e.preventDefault();
        const registerData = Object.fromEntries(new FormData(e.currentTarget));

        if (registerIsInvalid(registerData)) {
            alert('All fields must be filled!');
            return;
        }

        const { email, password, repeatPassword } = registerData;


        if (repeatPassword != password) {
            alert('Pass missmatch!');
            return;
        }

        userService.register(email, password)
            .then(() => {
                ctx.page.redirect('/');
            })
            .catch(error => {
                alert(error);
            });
    };

    ctx.render(registerTemplate(submitHandler));
}