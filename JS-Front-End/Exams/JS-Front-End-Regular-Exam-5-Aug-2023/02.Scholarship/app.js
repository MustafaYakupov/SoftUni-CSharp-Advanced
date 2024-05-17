window.addEventListener("load", solve);

function solve() {
  const studentInputElement = document.getElementById('student');
  const universityInputElement = document.getElementById('university');
  const scoreInputElement = document.getElementById('score');
  const nextButton = document.getElementById('next-btn');
  const previewListElement = document.getElementById('preview-list');
  const candidatesList = document.getElementById('candidates-list');

  nextButton.addEventListener('click', () => {
    // Get input data
    const studentName = studentInputElement.value;
    const university = universityInputElement.value;
    const score = scoreInputElement.value;

    // Check if empty
    if (!studentName || !university || !score) {
      return;
    }

    // Create DOM structure
    const editButton = document.createElement('button');
    editButton.classList.add('action-btn');
    editButton.classList.add('edit');
    editButton.textContent = 'edit';

    // Attach event on edit
    editButton.addEventListener('click', () => {
      // Populate input fields
      studentInputElement.value = studentName;
      universityInputElement.value = university;
      scoreInputElement.value = score;

      // Delete record from preview list
      applicationLi.remove();

      // Enable next button
      nextButton.disabled = false;
    })

    const applyButton = document.createElement('button');
    applyButton.classList.add('action-btn');
    applyButton.classList.add('apply');
    applyButton.textContent = 'apply';

    // Attach event on apply
    applyButton.addEventListener('click', () => {
      // Delete record from preview list
      applicationLi.remove();

      // Append to candidates list
      candidatesList.appendChild(applicationLi);


      // Remove edit and apply buttons
      applyButton.remove();
      editButton.remove();

      // Enable next button
      nextButton.disabled = false;
    })

    const scoreP = document.createElement('p');
    scoreP.textContent = `Score: ${score}`;

    const universityP = document.createElement('p');
    universityP.textContent = `University: ${university}`;

    const nameH4 = document.createElement('h4');
    nameH4.textContent = studentName;

    const studentInfoArticle = document.createElement('article');

    studentInfoArticle.appendChild(nameH4);
    studentInfoArticle.appendChild(universityP);
    studentInfoArticle.appendChild(scoreP);

    const applicationLi = document.createElement('li');
    applicationLi.classList.add('application');

    applicationLi.appendChild(studentInfoArticle);
    applicationLi.appendChild(editButton);
    applicationLi.appendChild(applyButton);

    previewListElement.appendChild(applicationLi);

    // Disable next button
    nextButton.disabled = true;

    // Clear input
    ClearInputData();
  })



  function ClearInputData() {
    studentInputElement.value = '';
    universityInputElement.value = '';
    scoreInputElement.value = '';
  }
}
