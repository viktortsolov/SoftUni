window.addEventListener("load", solve);

function solve() {
  const publishBtn = document.querySelector('#publish-btn');

  const reviewList = document.querySelector('#review-list');
  const publishedList = document.querySelector('#published-list');

  const titleElement = document.querySelector('#post-title');
  const categoryElement = document.querySelector('#post-category');
  const contentElement = document.querySelector('#post-content');

  publishBtn.addEventListener('click', (e) => {
    e.preventDefault();

    const title = titleElement.value;
    const category = categoryElement.value;
    const content = contentElement.value;

    if (title == `` || category == `` || content == ``) {
      return;
    }

    const li = document.createElement('li');
    li.classList.add('rpost');

    const article = document.createElement('article');

    const titleH4 = document.createElement('h4');
    titleH4.textContent = title;

    const categoryP = document.createElement('p');
    categoryP.textContent = `Category: ${category}`;

    const contentP = document.createElement('p');
    contentP.textContent = `Content: ${content}`;

    article.appendChild(titleH4);
    article.appendChild(categoryP);
    article.appendChild(contentP);

    const btnEdit = document.createElement('button');
    btnEdit.classList.add('action-btn');
    btnEdit.classList.add('edit');
    btnEdit.textContent = 'Edit';
    btnEdit.addEventListener('click', () => {
      e.preventDefault();

      titleElement.value = title;
      categoryElement.value = category;
      contentElement.value = content;

      reviewList.removeChild(li);
    });


    const btnApprove = document.createElement('button');
    btnApprove.classList.add('action-btn');
    btnApprove.classList.add('approve');
    btnApprove.textContent = 'Approve';
    btnApprove.addEventListener('click', () => {
      e.preventDefault();

      li.removeChild(btnApprove);
      li.removeChild(btnEdit);

      reviewList.removeChild(li);
      publishedList.appendChild(li);
    });

    li.appendChild(article);
    li.appendChild(btnApprove);
    li.appendChild(btnEdit);

    reviewList.appendChild(li);

    titleElement.value = ``;
    categoryElement.value = ``;
    contentElement.value = ``;
  });

  const clearBtn = document.querySelector('#clear-btn');
  clearBtn.addEventListener('click', (e) => {
    e.preventDefault();

    publishedList.innerHTML = ``;
  })
}
