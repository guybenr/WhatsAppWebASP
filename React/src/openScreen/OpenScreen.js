import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { Modal, Button } from "react-bootstrap";
import ErrorModal from "../errorModal/ErrorModal";
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { WebAPIServer, ReactServer, MVCServer } from "../Resources/resources"

function OpenScreen(props) {
    const navigate = useNavigate();
    const [isInvalid, setIsInvalid] = React.useState(false);


    const handleClose = () => {
        setIsInvalid(false);
    }
    const handleShow = () => {
        setIsInvalid(true);
    }

    const handleSubmit = async (event) => {
        event.preventDefault();
        var username = document.getElementById('username').value;
        var password = document.getElementById('exampleInputPassword1').value;
        let loginDetails = { Username: username, Password: password };
        let token = await fetch("http://" + WebAPIServer + "/api/users/login", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "Accept":"application/json"
            },
            body: JSON.stringify(loginDetails)
        });
        token = await token.json();
        if(token === "Invalid username or password") {
            handleShow();
            return;
        }

        let userDetails = await fetch("http://" + WebAPIServer + "/api/users", {
            method: 'GET',
            headers: {
                "Accept":"application/json",
                "Authorization": "Bearer " + token
            },
        });
        userDetails = await userDetails.json();
        props.onSignIn(userDetails); //passing all of the user details to the chatScreen component
        props.setUserToken(token);   //passing the token to the chatScreen component
        navigate('/Chat');
        
    }


    return (
        <main>
            <div className="home" id="main-div">
                <div className="box shadow-lg p-3 mb-5 bg-body rounded">
                    <label className="login">Login</label>
                    <form onSubmit={handleSubmit}>
                        <div className="mb-3">
                            <label htmlFor="username" className="form-label">Username</label>
                            <input className="form-control username form1" id="username" aria-describedby="emailHelp" placeholder="Email /&nbsp;Username"></input>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleInputPassword1" className="form-label">Password</label>
                            <input type="password" className="form-control password form1" id="exampleInputPassword1" placeholder="Password"></input>
                        </div>
                        <div className="mb-3">
                            <label>Not register?&nbsp;</label>
                            <Link to='/Register'>Click here</Link>
                            <label>&nbsp;to register</label>
                        </div>
                        <div>
                            <button onClick={handleSubmit} type="submit" className="btn btn-primary">Log in</button>
                        </div>
                    </form>
                    <div className="mb-3">
                        <a href={"http://" + MVCServer + "/reviews/index"} className="allRate">
                            <img className="rate-link" src="https://azcdn.odyssey.pgsitecore.com/en-us/-/media/HerbalEssence/Images/Common%20Icons/RatingStars.png?v=1-201704181136"></img>
                            <h1 className="rate">Rate Us</h1>
                        </a>
                    </div>
                </div>
                <ErrorModal handleShow={isInvalid} handleClose={handleClose} bodyMassage="Invalid username or password" closeButton="Close" />
            </div>
        </main>
    );
};



export default OpenScreen;