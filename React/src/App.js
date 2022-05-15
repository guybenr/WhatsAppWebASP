import './App.css';
import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import RegisterScreen from './registerScreen/RegisterScreen'
import OpenScreen from './openScreen/OpenScreen'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ChatScreen from './chatScreen/chatScreen';



function App() {
  const [userLoginDetails, setUserLoginDetails] = React.useState('');
  const [userToken, setUserToken] = React.useState('');


  return (
    <BrowserRouter>
      <Routes>
        <Route path='/Register' element={<RegisterScreen setUserToken={setUserToken} onSignUp={setUserLoginDetails}/>}></Route>
        <Route path='/' element={<OpenScreen setUserToken={setUserToken} onSignIn={setUserLoginDetails} />}></Route>
        <Route path='/Chat' element={<ChatScreen userToken={userToken} userLoginDetails={userLoginDetails}/>}></Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
