import React, {useState} from 'react';
import NewUserForm from './containers/NewUserForm';
import UserLoginForm from './containers/UserLoginForm';



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
