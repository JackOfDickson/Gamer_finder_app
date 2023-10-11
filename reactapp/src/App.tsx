import React, {useState} from 'react';
import NewUserForm from './components/NewUserForm';
import UserLoginForm from './components/UserLoginForm';



function App() {

  return (
    
    <div className="App">
      <header className="App-header">
              <p>Hello</p>
              <UserLoginForm/>
              <NewUserForm/>
              
      </header>
    </div>
  );
}

export default App;
