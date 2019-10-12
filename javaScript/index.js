let logInHtmlRender = document.getElementById("logIn");
let homepageHtmlRender = document.getElementById("homePage");
let currentUser;

// API DATA SECTION & ARRAYs

let userArray = [];
let EventArray = [];

//Global Functions
//TODO SORT BY EVENT CREATION DATE // CHANGES
function sortEventsArrays(events) {
  return events.sort(function(parametarOne, parametarTwo) {
    let itemOne = parametarOne.eventName;
    let itemTwo = parametarTwo.eventName;

    if (itemOne < itemTwo) {
      return -1;
    }
    if (itemOne > itemTwo) {
      return 1;
    }

    return 0;
  });
}

function getMailsFromUsers() {
  userArray.forEach(element => {
    console.log(element.email);
  });
}


// / TODO This is calling on two places with different css style need to be checked
function createEventInputs() {
  return `<div>
    <input type="text" />Event Name
    <textarea name="" id="" cols="30" rows="10">Description</textarea>
    <input type="date" />Event Start <input type="date" />Event End
    <input type="text" />Event Location <input type="text" />Departure
    Location 
    <input type="text" />Event Creator
    <button>Create</button>
    </div>`;
}

function RenderLogInPage() {
  logInHtmlRender.innerHTML = `
       <div>
          <p>Username</p>
           <input type="text" id="usernameInput">
           <p>Password</p>
           <input type="text" id="passwordInput">
           <button id="LogInBtn">log In</button>
      </div>
      `;
}
RenderLogInPage();

//API Call function
function userDataApiCall() {
  let response = fetch(
    "https://raw.githubusercontent.com/DonevskiFilip/PublicAPI/master/LetsDoItApi.json"
  )
    .then(x => x.json())
    .then(x => {
      return x;
    });
  return response;
}
//Get Buttons By ID section
let logInBtn = document.getElementById("LogInBtn");

// Get All Input Values section

let logInUsernameInput = document.getElementById("usernameInput");
let logInPasswordInput = document.getElementById("passwordInput");

//Buttons event Listeners

logInBtn.addEventListener("click", async function() {
  let apiCall = await userDataApiCall();
  userArray = apiCall.Users;
  EventArray = sortEventsArrays(apiCall.Events);

  getMailsFromUsers();

  let trueUser = userArray.find(
    x =>
      x.email === logInUsernameInput.value &&
      x.password === logInPasswordInput.value
  );
  if (trueUser !== undefined && trueUser !== null) {
    console.log("Loged IN");
    currentUser = trueUser;
    console.log("this is currnetUser" + currentUser.email);
    logInHtmlRender.style.display = "none";
    renderHomePage(trueUser);
  }
  console.log("Wrong");
});

// TODO Change EVENTS INFO!!!!!
// TO DO (for users created events remove join button or if events spots are full remove join button)
function renderEventsContainer() {
  let eventContainer = document.getElementById("EventsContainer");
  // createEventInputs(eventContainer);

  eventContainer.innerHTML = createEventInputs();
  EventArray.forEach(element => {
    `${(eventContainer.innerHTML += `<div>
        <div id="eventName">${element.eventName}</div>
        <div id="eventStart">${element.startDate}</div>
        <div id="eventEnd">${element.endDate}</div>
        <div id="eventDuration">${element.eventName}</div>
        <div id="eventSpots">${element.eventSpots}</div>
        <div id="eventLocation">${element.eventLocation}</div>
        <div id="eventCreator">${element.eventCreator}</div>
        <button value=${element.eventID}>JOIN</button>
        </div>`)}`;
  });

  // EventLIstener for JOIN EVENT BUTTON
  let joinEventBtn = document.getElementById("EventsContainer");
  joinEventBtn.addEventListener("click", function(e) {
    e.preventDefault();
    let eventClicked = e.target.getAttribute("value");
    currentUser.goingeventID = eventClicked;
  });
}

function renderHomePage(user) {
  homepageHtmlRender.innerHTML = `
  <div>
    <div>
        <button id="homeBtn">Home</button>
        <button id="profileBtn">${user.firstName}</button>
        <button id="logOutBtn">Log Out</button>
    </div>
    <div id=>
    <div id="EventsContainer">
    </div>
</div>`;

  renderEventsContainer();
}
