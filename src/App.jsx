import React from 'react'
import { Header } from './components/Header'
import Nav from './components/Nav'
import $ from "jquery";
import { useEffect } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './components/Home';
import InsertUser from './components/InsertUser';

function App() {
  useEffect(()=>{
      $(".nav > a").hover(function(){
        $(this).css("color", "#2AABFF");
      }, function(){
        $(this).css("color", "#444");
      });
      $(".nav > a").css("cursor", "pointer");
  },[])

  return (
    <>
      <BrowserRouter>
        <Header />
        <Nav />
          <Routes>
            <Route path='/' element={<Home />} />
            <Route path='/insertar_empleado' element={<InsertUser />} />
          </Routes>
      </BrowserRouter>
    </>
  )
}

export default App