import page from '../node_modules/page/page.mjs';

import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderNavigationMiddleware, renderContentMiddleware } from './middlewares/renderMiddleware.js';
import { createView } from './views/createView.js';
import { deleteView } from './views/deleteView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';


import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { myPostView } from './views/mypostsView.js';
import { registerView } from './views/registerView.js';

page(authMiddleware);
page(renderNavigationMiddleware);
page(renderContentMiddleware);

page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/logout', logoutView);
page('/create', createView);
page('/posts/:postId', detailsView);
page('/posts/:postId/edit', editView);
page('/posts/:postId/delete', deleteView);
page('/myposts', myPostView);

page.start();