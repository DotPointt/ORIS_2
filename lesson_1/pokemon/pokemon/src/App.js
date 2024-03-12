import './App.css';

import {useCallback, useEffect, useState} from 'react';
import Header from './Components/Header';
import Content from './Components/Content';

import {usePokemonStore} from "./Components/PokemonStateStore.jsx"

const url = 'https://pokeapi.co/api/v2/pokemon/?limit=150';

function App() {
  const[state, setState] = useState(0);
  const[cards, setCards] = useState();  


  const {pokemonsList, setPokemonsList, refreshPokemonsList} = usePokemonStore();


  useEffect( () => {
    const fetchPokemons = async () =>{
      const response = await fetch(url);
      const cards = await response.json();
      setCards(cards);

      setPokemonsList(cards.results);
      console.log("CARDS RESULTS")
      console.log(cards.results)
    };

    fetchPokemons();
  }, []);

  
  if (!cards) {
    return <div>...</div>; 
  }

  return (
    <div className="App">

      <Header/>
      
      <Content cards={cards}/>

    </div>
  )

  


  }

export default App;

