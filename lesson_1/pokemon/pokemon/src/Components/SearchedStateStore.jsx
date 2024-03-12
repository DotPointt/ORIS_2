import {create} from "zustand";
export const useSearchedPokemonStore = create((set) =>({
    searchedPokemonsList: [],
        setSearchedList: (pokemons) => {
        set(() => ({
            searchedPokemonsList: pokemons
        }))
    },
    refreshSeearchedList: () => {
        set(() => ({
            searchedPokemonsList: []
        }))
    }
}));