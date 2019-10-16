class User {
  constructor(
    firstName,
    lastName,
    email,
    password,
    region,
    gender,
    birthDay,
    profilePhoto
  ) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.password = password;
    this.region = region;
    this.gender = gender;
    this.birthday = birthDay;
    this.createdID = null;
    this.goingeventID = null;
    this.userId = GeneratedID();
    this.profilePhoto = profilePhoto;
  }
}

class Event {
  constructor(
    eventname,
    eventdescription,
    startdate,
    enddate,
    eventlocation,
    departurelocation,
    eventspots,
    eventcreator
  ) {
    this.eventName = eventname;
    this.eventDescription = eventdescription;
    this.startDate = startdate;
    this.endDate = enddate;
    this.eventLocation = eventlocation;
    this.departureLocation = departurelocation;
    this.eventSpots = eventspots;
    this.eventId = GeneratedID();
    this.eventCreator = eventcreator;
  }
}

let logInHtmlRender = document.getElementById("logIn");
let homepageHtmlRender = document.getElementById("homePage");
let profilePageHtmlRender = document.getElementById("profilePage");
let currentUser;
let trueUser;
let eventContainerHomePage = document.getElementById("EventsContainer");
let navHeader = document.getElementById("navHeader");
let displayProfileEvents;
let eventsInfoDiv;
let userListDiv = document.getElementById("usersList");

// ALL BUTTONS DEFINE HERE

let myProfileBtn = document.getElementById("profileBtn");

let lotOutBtn;
let homePageBtn = document.getElementById("homeBtn");
let joinEventBtn = document.getElementById("EventsContainer");
let logInBtn = document.getElementById("LogInBtn");
let createdEventsBtn;
let goingToEventsBtn;

// Log In And Registration HTML ELEMENTS
let logInUsernameInput = document.getElementById("usernameInput");
let logInPasswordInput = document.getElementById("passwordInput");
let registrationFirstName = document.getElementById("regFirstName");
let registrationLastname = document.getElementById("regLastname");
let registrationEmail = document.getElementById("regEmail");
let registrationPassword = document.getElementById("regPassword");
let registrationConfPassword = document.getElementById("regConfirmPassword");
let registrationRegion = document.getElementById("regRegion");
let registrationGender = document.getElementById("regGender");
let registrationBirthday = document.getElementById("regDate");
let registrationBtn = document.getElementById("registrationBtn");

// FUNCTIONS FOR AUTO GENERATED DIVS
function generateProfilePage(user) {
  profilePageHtmlRender.style.display = "flex";
  profilePageHtmlRender.innerHTML = `<div id="profilePageConteiner">
  <div id="profilPhotoDiv">
    <img src="${user.profilePhoto}" alt="" />
  </div>
  <div id="userInfoDiv">
    <div id="fullName">
      <h3>${user.firstName} ${user.lastName}</h3>
    </div>
    <div id="birthInfoDiv">${user.birthday}</div>
    <div id="otherInfoDiv">
      <div>Region:${user.region}</div>
      <div>Gender:${user.gender}</div>
      <div>Email: ${user.email}</div>
    </div>
  </div>
  <div id="EventsInfoDiv">
    <div>
      <div id="createdEvent" value = "created">Created Events</div>
      <div id="goingToEvent" value = "going">Going To Event</div>
    </div>
    <div id="prfileDisplayEventsDiv">
    </div>
  </div>
</div>`;
  createdEventsBtn = document.getElementById("createdEvent");
  goingToEventsBtn = document.getElementById("goingToEvent");
  displayProfileEvents = document.getElementById("prfileDisplayEventsDiv");
  eventsInfoDiv = document.getElementById("EventsInfoDiv");

  eventsInfoDiv.addEventListener("click", function(e) {
    e.preventDefault();
    debugger;
    let clickTarget = e.target.getAttribute("value");
    displayProfileEventsInfo(clickTarget, currentUser);
  });
}
function displayProfileEventsInfo(targetValue, userId) {
  displayProfileEvents.innerHTML = "";
  debugger;
  if (targetValue === "created") {
    let userEvents = EventArray.find(x => x.eventID === userId.createdID);
    if (userEvents !== undefined) {
      displayProfileEvents.innerHTML = `<div>
      <div id="eventName">${userEvents.eventName}</div>
      <div id="eventStart">${userEvents.startDate}</div>
      <div id="eventEnd">${userEvents.endDate}</div>
      <div id="eventDuration">${userEvents.eventName}</div>
      <div id="eventSpots">${userEvents.eventSpots}</div>
      <div id="eventLocation">${userEvents.eventLocation}</div>
      <div id="eventCreator">${userEvents.eventCreator}</div>
      </div>`;
    }
  }
  if (targetValue === "going") {
    displayProfileEvents.innerHTML = "";
    let userEvents = EventArray.find(x => x.eventID === userId.goingeventID);
    if (userEvents !== undefined) {
      displayProfileEvents.innerHTML = `<div>
      <div id="eventName">${userEvents.eventName}</div>
      <div id="eventStart">${userEvents.startDate}</div>
      <div id="eventEnd">${userEvents.endDate}</div>
      <div id="eventDuration">${userEvents.eventName}</div>
      <div id="eventSpots">${userEvents.eventSpots}</div>
      <div id="eventLocation">${userEvents.eventLocation}</div>
      <div id="eventCreator">${userEvents.eventCreator}</div>
      </div>`;
    }
  }
}
function generateUserList(usersArray) {
  userListDiv.innerHTML = "";
  userArray.forEach(element => {
    userListDiv.innerHTML += `<div>${element.firstName} ${element.lastName}</div>`;
  });
}

//DOM MNIPULATION HIDE & SHOW
homepageHtmlRender.style.display = "none";
profilePageHtmlRender.style.display = "none";

// API DATA SECTION & ARRAYs
let userArray = [];
let EventArray = [];

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
async function DataBaseCall() {
  let response = await userDataApiCall();
  userArray = response.Users;
  EventArray = sortEventsArrays(response.Events);
}
DataBaseCall();

// Front Page Buttons LogIn / Register
logInBtn.addEventListener("click", async function() {
  getMailsFromUsers();
  userArray.find(x => {
    if (
      x.email === logInUsernameInput.value &&
      x.password === logInPasswordInput.value
    ) {
      trueUser = x;
    }
  });

  if (trueUser !== undefined && trueUser !== null) {
    currentUser = trueUser;
    logInHtmlRender.style.display = "none";
    homepageHtmlRender.style.display = "flex";
    renderEventsContainer();
    generateUserList(userArray);

    myProfileBtn.innerHTML = `${currentUser.firstName} ${currentUser.lastName}`;
  }
  console.log("Wrong");
});

registrationBtn.addEventListener("click", function() {
  validationAndRegisterUser(
    registrationFirstName.value,
    registrationLastname.value,
    registrationEmail.value,
    registrationPassword.value,
    registrationConfPassword.value,
    registrationRegion.value,
    registrationGender.value,
    registrationBirthday.value,
    null
  );
});

function validationAndRegisterUser(
  firstName,
  lastName,
  email,
  password,
  confirmPassword,
  region,
  gender,
  birthDay,
  profilePhoto
) {
  debugger;
  if (isNaN(firstName) === false) {
    return true;
  }
  if (isNaN(lastName) === false) {
    return true;
  }
  if (
    /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email) === false ||
    userArray.find(function(x) {
      x.email === email;
    }) != undefined
  ) {
    alert("Wrong Email");
    return false;
  }
  if (password !== confirmPassword || password.length < 5) {
    return false;
  }
  if (profilePhoto === null || profilePhoto === undefined) {
    profilePhoto =
      "https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwiznYj63pnlAhUSU1AKHcgLAREQjRx6BAgBEAQ&url=https%3A%2F%2Fthe-test-fun-for-friends.en.softonic.com%2Fiphone&psig=AOvVaw1OJld5-RtwhPQsGTP4AlHS&ust=1571073454890079";
  }
  let newUser = new User(
    firstName,
    lastName,
    email,
    password,
    region,
    gender,
    birthDay,
    profilePhoto
  );
  console.log(newUser.firstName);
  userArray.push(newUser);
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

// HOME page Buttons HOME / myProfile / Log out
myProfileBtn.addEventListener("click", function() {
  eventContainerHomePage.style.display = "none";
  navHeader.style.display = "flex";
  userListDiv.style.display = "none";
  generateProfilePage(currentUser);
});
homePageBtn.addEventListener("click", function() {
  profilePageHtmlRender.style.display = "none";
  homepageHtmlRender.style.display = "flex";
  eventContainerHomePage.style.display = "flex";
  userListDiv.style.display = "flex";
  renderEventsContainer();
  generateUserList(userArray);
});

// TODO Change EVENTS INFO!!!!!
// TO DO (for users created events remove join button or if events spots are full remove join button)
function renderEventsContainer() {
  eventContainerHomePage.innerHTML = "";
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
}
// EventLIstener for JOIN EVENT BUTTON
joinEventBtn.addEventListener("click", function(e) {
  e.preventDefault();
  let eventClicked = e.target.getAttribute("value");
  if (
    currentUser.goingeventID !== null ||
    currentUser.goingeventID !== undefined
  ) {
    return alert("You can attend on one event");
  }
  currentUser.goingeventID = eventClicked;
});

//HELPERS FUNCTIONS
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

//Delete When YOU finish
function getMailsFromUsers() {
  userArray.forEach(element => {
    console.log(element.email);
  });
}

function GeneratedID() {
  let idLength = 5;
  let char = "qwertyuiopasdfghjklzxcvbnm1234567890".split("");
  let returnId = "";

  for (i = 0; i < idLength; i++) {
    returnId += char[Math.floor(Math.random() * char.length)];
  }
  return returnId;
}
