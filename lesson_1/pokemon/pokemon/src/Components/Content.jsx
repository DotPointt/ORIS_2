import React from "react";
import { useState, useEffect } from "react";
import './Content.css'
import Card from "./Card";


const Content = function(props){
    
  const PokemonList = props.list

  console.log(PokemonList)


  if (!PokemonList){
    return <div>Content LOading...</div>; 
  }

  console.log(PokemonList);

  if (PokemonList.length > 0) {
      return (
            <div className='content'>

              {PokemonList.map( (card) => {

                return  <Card key={card.name} card={card} />
              })}
          </div>
      )
  }
  else {
      return (
          <div >
              <h1>Oops! Try again.</h1>
              <span>The Pokemon you're looking for doesn't exist in this list.</span>
              <img src="adfaef.png" alt="pikachu" />
          </div>
      )
  }

}


export default Content;