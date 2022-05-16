import { useRef, useEffect } from "react";
import Massage from "../massage/Massage";
import React from "react";
import { Modal } from "react-bootstrap";
import { render } from "react-dom";
import useRecorder from "./useRecorder";
import UsersData from "../usersData/UsersData";


function Chat(props) {
    const [messages, setMessages] = React.useState([]);
    const toSendMassage = React.createRef('');

    useEffect(async () => {
        let messages = await fetch("http://localhost:5028/api/contacts/" + props.contact.id + "/messages/", {
            method: 'GET',
            headers: {
                "Authorization": "Bearer " + props.userToken
            },
        });
        setMessages(await messages.json());
        console.log(messages);
    },[props.reRender, props.chatName]);

    //function returns all of the Massage Components that are in the database
    const massagesList = messages.map((message, key) => {
        if (message.content !== "")
            return <Massage content={message.content} isRecived={!message.sent} time={new Date(Date.parse(message.created))} type={"text"}/>
        return <></>
    }).reverse();

    var ImageChat = "https://cdn-icons.flaticon.com/png/128/924/premium/924915.png?token=exp=1652717894~hmac=9f724ce5c0a58cc9ece3e0107ded640e"

    //function handeling sending massage to a contact
    const sendMessage = async (event) => {
        let messageContent = toSendMassage.current.value;
        if (event.key !== "Enter" || messageContent === "")
            return;
        event.preventDefault();
        let message = {from: props.currentUserId, to: props.contact.id, content: messageContent}
        console.log(message);
        //post to the server
        await fetch("http://localhost:5028/api/contacts/" + message.to + "/messages", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "Accept": "application/json",
                "Authorization": "Bearer " + props.userToken
            },
            body: JSON.stringify({content : messageContent})
        });
        // transfer to the contact's server
        await fetch("http://"+ props.contact.server + "/api/transfer", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "Accept": "application/json",
            },
            body: JSON.stringify(message)
        });
        toSendMassage.current.value = "";
        props.setReRender(!props.reRender);
    }

    return (
        <div className="right-chat">
            <div className="headingChat">
                <div className="chatPhoto">
                    <img src={ImageChat} className="profileImg"></img>
                </div>
                <a className="chatName">{props.chatName}</a>
                <span className="heading-online">Online</span>
            </div>
            <div className="allMessages">
                {massagesList}
            </div>
            <div className="chat-box">
                <div className="toSend">
                    <input onKeyPress={sendMessage} ref={toSendMassage} type="text" class="form-control textBox"></input>
                    <span className="glyphicon glyphicon-search form-control-feedback"></span>
                </div>
            </div>
        </div>
    );
}

export default Chat;