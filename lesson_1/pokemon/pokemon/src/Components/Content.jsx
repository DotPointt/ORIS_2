import React from "react";
import { useState, useEffect } from "react";
import './Content.css'
import Card from "./Card";

import {usePokemonStore} from "./PokemonStateStore.jsx"
import {useSearchedPokemonStore} from "./SearchedStateStore.jsx";

const Content = function(props){
    
  const {pokemonsList, setPokemonsList, refreshPokemonsList} = usePokemonStore();
  const {searchedPokemonsList, setSearchedList} = useSearchedPokemonStore();

  useEffect(() =>{
    setSearchedList(pokemonsList)
  }, [pokemonsList])

  console.log("SEARCHEDPOKEMONSLIST")
console.log(searchedPokemonsList)

console.log("CARDSRESULTS")
console.log(pokemonsList)

  if (searchedPokemonsList.length > 0) {
      return (
            <div className='content'>

            {props.cards.results.map( (card) => {

              return  <Card card={card} />
            })}
            <div className='post'></div>
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

    return(
      <div className='content'>
        
        {props.cards.results.map( (card) => {
          return  <Card card={card} />
        })}
        <div className='post'></div>
      </div>
    )
}


export default Content;