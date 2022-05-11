import React, { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import ErrorModal from "../errorModal/ErrorModal";
import UsersData from "../usersData/UsersData";
import { Modal, Button } from "react-bootstrap";
import ContactItem from "../contactItem/ContactItem";
import Search from "../search/Search";
import Chat from "../chat/Chat";
import ContactListResult from "../contactsListResult/ContactListResult";

function ChatScreen(props) {
    const navigate = useNavigate();
    const contactUsername = React.createRef('');
    const contactNickName = React.createRef('');
    const contactServer = React.createRef('');

    const [toAddContact, setToAddContact] = React.useState(false);
    const [contacts, setContacts] = React.useState(UsersData.usersChat.get(props.userLoginDetails));
    const [showChat, setshowChat] = React.useState(false);
    const [detailsChat, setDetailsChat] = React.useState("");
    const [reRender, setReRender] = React.useState(false);

    // useEffect(async () => {
    //     let contactsResponse = await fetch("http://localhost:5028/api/contacts", {
    //         method: 'GET',
    //         headers: {
    //             "Authorization": "Bearer " + localStorage.getItem("user-token")
    //         },
    //         body: ""
    //     });
    //     setContacts(await contactsResponse.json());
    // });

    const contactName = React.createRef('');

    //function responsible on showing the modal contact
    const showAddContactModal = (event) => {
        event.preventDefault();
        setToAddContact(true);
    }

    // function adding the contact to the database
    const addContact = async (event) => {
        event.preventDefault();
        if (contactUsername.current.value === '' || contactNickName.current.value === '' || contactServer.current.value === '') { // validation that the input isnt empty
            return;
        }
        let userName = props.userLoginDetails;
            //if the contact try to add himself
        if (contactUsername.current.value === userName && contactServer.current.value === "localhost:5028") {
            alert("Contact can't add himself");
            return;
        } else if (contacts.find( c => c.id === contactUsername.current.value && c.server === contactServer.current.value) !== undefined) {
            alert("Contact already added");
            return;
        }
        let transfer = {from: userName, to: contactUsername.current.value, server: contactServer.current.value };
        let result = await fetch("http://"+ transfer.server + "/api/invitations/", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "Accept": "application/json",
            },
            body: JSON.stringify(transfer)
        });
        if(result.status !== 201) {
            alert("Invalid Details");
            return;
        }
        result = await fetch("http://localhost:5028/api/invitations/", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "Accept": "application/json",
            },
            body: JSON.stringify(transfer)
        });
        contactUsername.current.value = "";
        contactNickName.current.value = "";
        contactServer.current.value = "";
        setToAddContact(false);
    }

    const doSearch = (query) => {
        setContacts(contacts.filter((contact) => contact.name.includes(query)));
    }


    const showOpenChat = (event) => {
        event.preventDefault();
        setshowChat(true);
    }

    var name;
    var image;
    for (let i = 0; i < UsersData.usersList.length; ++i) {
        if (UsersData.usersList[i].userName === props.userLoginDetails) {
            name = UsersData.usersList[i].nickName;
            image = UsersData.usersList[i].image;
            break;
        }
    }


    const logOut = (event) => {
        event.preventDefault();
        navigate('/');
    }


    return (
        <div>
            <div className="app">
                <div className="chatDetails">
                    <div className="heading">
                        <div className="circleProfile">
                            <img className="profileImg" src={image}></img>
                        </div>
                        <button onClick={logOut} type="button" className="btn btn-secondary">
                            <span className="LogOut">Log out</span>
                        </button>
                        <div className="MyName">{name}
                            <button className="addChat btn btn-outline-secondary" type="submit" onClick={showAddContactModal}>+</button>
                        </div>
                    </div>
                    <Search setSearchQuery={doSearch} />
                    <ContactListResult contactsList={contacts} showChat={showOpenChat} setDetails={setDetailsChat} />
                </div>
                {(detailsChat !== "") && <Chat currentUserId={props.userLoginDetails} contact={detailsChat} 
                                            chatName={detailsChat.name} setReRender={setReRender} reRender={reRender} />}
                <Modal show={toAddContact} onHide={() => setToAddContact(false)}>
                    <Modal.Header closeButton>
                        <Modal.Title>Add new contact</Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <form>
                            <input className="form-control me-2 add-contact" type="search" placeholder="Username" aria-label="Search" ref={contactName}></input>
                            <input className="form-control me-2 add-contact" type="search" placeholder="Nick Name" aria-label="Search" ref={contactNickName}></input>
                            <input className="form-control me-2 add-contact" type="search" placeholder="Server" aria-label="Search" ref={contactServer}></input>
                        </form>
                    </Modal.Body>

                    <Modal.Footer>
                        <Button onClick={addContact} variant="primary">Add</Button>
                    </Modal.Footer>
                </Modal>
            </div>
        </div>
    );
}

export default ChatScreen;