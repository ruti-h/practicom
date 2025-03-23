// import React from 'react';

import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import LoginCandidate from "./components/loginCandidate";
import Login from "./components/loginCandidate";
//import { UserProvider } from "./components/useContext";
// const rotes= createBrowserRouter([
//   {
//     path:"/",
//     element:<Login/>
//   }
// ])
const App = () => {
  return (
  
    // <UserProvider>
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<LoginCandidate />} />
        <Route path="*" element={<Navigate to="/" />} /> {/* ברירת מחדל לדף הבית */}
      </Routes>
    </Router>
  // </UserProvider>
  );
};

export default App;