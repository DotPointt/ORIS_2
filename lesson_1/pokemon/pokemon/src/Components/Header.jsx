import './Header.css'
import React from "react";
import { useState, useEffect } from "react";

import {usePokemonStore} from "./PokemonStateStore.jsx"
import {useSearchedPokemonStore} from "./SearchedStateStore.jsx";

const Header = function(){

  const [searchInput, setSearchInput] = useState('');
  const [searchResult, setResult] = useState([]);
  const {pokemonsList} = usePokemonStore();
  const {setSearchedList } = useSearchedPokemonStore()

  useEffect(() => {
      if (searchInput.length !== 0) {
          const filiteredPokemons = pokemonsList.filter((item) => {
              return (item.pokemon.name)
          });
          console.log("po")
          console.log(pokemonsList);
          setResult(filiteredPokemons);
      }
      else{
          setResult(pokemonsList);
      }
  }, [searchInput])

  useEffect(() =>{
      setSearchedList(searchResult);
  }, [searchResult])

  const searchPokemons = (value) =>{
      setSearchInput(value)
  }


    return(
        <header>
          <img className='pokeball' src='image.png'/>  
        <div className='searchContainer'>
          <p>Whom are you looking for?</p>
          <div className='searchLine'>
            <img className='magnifier' src='search.png'/> 
            <input className='searchBar' placeholder='        E.g Pikachu' onChange={(e) => searchPokemons(e.target.value)}></input> 
            <button className='btn'>GO</button>
          </div>
        </div>
    </header>
    )
}


export default Header;