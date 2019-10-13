let logInHtmlRender = document.getElementById("logIn");
let homepageHtmlRender = document.getElementById("homePage");
let profilePageHtmlRender = document.getElementById("profilePage");
let currentUser;
let eventContainerHomePage;

// ALL BUTTONS DEFINE HERE

let myProfileBtn;
let lotOutBtn;
let homePageBtn;
let joinEventBtn;
let logInBtn;
let reatedEventsBtn;
let goingToEventsBtn;

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

function createProfilePageDivs(userId) {
  eventContainerHomePage.style.display = "none";
  let showUserProfile = userArray.find(x => x.userId === userId);

  profilePageHtmlRender.innerHTML = `<div id="profilePageConteiner">
         <div id="profilPhotoDiv">
           <img src="${showUserProfile.profilePhoto}" alt="" />
        </div>
        <div id="userInfoDiv">
          <div id="fullName">
             <h3>${showUserProfile.firstName} ${showUserProfile.lastName}</h3>
           </div>
          <div id="birthInfoDiv">${showUserProfile.birthday}</div>
          <div id="otherInfoDiv">
            <div>Region:${showUserProfile.region}</div>
            <div>Gender:${showUserProfile.gender}</div>
            <div>Email: ${showUserProfile.email}</div>
          </div>
        </div>
        <div id="EventsInfoDiv">
        <div id="createdEvent">Created Events</div>
        <div id="goingToEvent">Going To Event</div>
        </div>
     </div>`;
}

// / TODO This is calling on two places with different css style need to be checked
function createEventInputs(
  neededDiv,
  nameVal,
  textAreaVal,
  startDateVal,
  endDateVal,
  eventLocationVal,
  eventDepartureVal,
  eventSpotsVal
) {
  neededDiv.innerHTML = `<div>
    <input type="text" id=${nameVal}Id  />Event Name
    <textarea id=${textAreaVal}Id cols="30" rows="10">Description</textarea>
    <input id=${startDateVal}Id type="date" />Event Start
    <input id=${endDateVal}Id type="date" />Event End
    <input id=${eventLocationVal}Id type="text" />Event Location 
    <input id=${eventDepartureVal}Id type="text" />Departure
    Location 
    <input id=${eventSpotsVal}Id type="number">Event spots
    <button>Create</button>
    </div>`;
}

function createEvent(
  name,
  description,
  eventStart,
  eventEnd,
  eventLocation,
  departureLocation,
  eventSpots
) {
  let todayDay = new Date();
  if (isNaN(name) === false || name === null || name.trim() === "") {
    alert("You didn`t enter valid name");
    return false;
  }
  if (
    isNaN(description) === false ||
    description === null ||
    description.trim() === ""
  ) {
    alert("You didn`t enter description");
    return false;
  }
  if (eventStart < todayDay) {
    alert(`Your event need to start form ${todayDay}`);
    return false;
  }
  if (eventEnd < eventStart) {
    alert(`Event end date can be beffor start date`);
    return false;
  }
  if (
    isNaN(eventLocation) === false ||
    eventLocation === null ||
    eventLocation.trim() === ""
  ) {
    alert("Need to enter event Location");
    return false;
  }
  if (
    isNaN(departureLocation) === false ||
    departureLocation === null ||
    departureLocation.trim() === ""
  ) {
    alert("Need to enter event Departure Location");
    return false;
  }
  if (isNaN(eventSpots) === true || departureLocation === null) {
    alert("Need to enter event spots");
    return false;
  }
  return true;
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
logInBtn = document.getElementById("LogInBtn");

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
async function renderEventsContainer() {
  createEventInputs(
    eventContainerHomePage,
    "homePageEventName",
    "homePageTextArea",
    "homePageStartDate",
    "homePageEndDate",
    "homePageLocation",
    "homePageDeparture",
    "homePageSpots"
  );
  EventArray.forEach(element => {
    `${(eventContainerHomePage.innerHTML += `<div>
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
  joinEventBtn = document.getElementById("EventsContainer");
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
    <div id="EventsContainer">
    </div>
</div>`;
  eventContainerHomePage = document.getElementById("EventsContainer");
  myProfileBtn = document.getElementById("profileBtn");
  renderEventsContainer();
  myProfileBtn.addEventListener("click", function() {
    createProfilePageDivs(currentUser.userId);
  });
}
