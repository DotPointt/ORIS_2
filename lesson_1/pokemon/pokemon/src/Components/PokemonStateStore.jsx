import {create} from "zustand";

export const usePokemonStore = create((set)=> ({
    pokemonsList: [],
        setPokemonsList: (pokemon) => {
        set((state) => ({
            pokemonsList: [
                ...state.pokemonsList,
                {
                    pokemon
                }
            ]
        }))
        },
    refreshPokemonsList: () =>{
        set(() =>({
            pokemonsList: []
        }))
    }
} )
);