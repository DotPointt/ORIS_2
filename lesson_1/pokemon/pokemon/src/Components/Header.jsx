import './Header.css'
import React from "react";
import { useState, useEffect } from "react";


const Header = function(props){

  const defaultPokemonList = props.list.results
  const [searchItem, setSearchItem] = useState('');
  const setSearchedList = props.setter;


  useEffect(() => {
    const Debounce = setTimeout(() => {
      const filteredPokemons = filterPokemons(searchItem, defaultPokemonList);

      setSearchedList(filteredPokemons);
    }, 300);

    return () => clearTimeout(Debounce);
  }, [searchItem])



    return(
        <header>
          <img className='pokeball' src='/ORIS_2/image.png'/>  
        <div className='searchContainer'>
          <p>Who are you looking for?</p>
          <div className='searchLine'>
            <img className='magnifier' src='/ORIS_2/search.png'/> 
            <input type='text' className='searchBar' placeholder='E.g Pikachu' onChange={(e) => setSearchItem(e.target.value)}></input> 
            <button className='btn'>GO</button>
          </div>
        </div>
    </header>
    )
}

const filterPokemons = (searchText, defaultList) =>{
  if(!searchText){
    return null;
  }

  return defaultList.filter(pokemon =>
  pokemon.name.toLowerCase().includes(searchText.toLowerCase())
  );

}

export default Header;

