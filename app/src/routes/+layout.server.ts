import { env } from "$env/dynamic/private";
import { parseMovie, type Movie } from "$lib/models/movie";

export async function load() {
    const movies = await loadMovies();
    
    let parsedMovies = movies.map(parseMovie);

    return {
        movies: parsedMovies
    };
}

async function loadMovies() {
    const response = await fetch(`${env.API_BASE_URL}/api/movies`);

    if (!response.ok) {
        throw new Error('Failed to fetch movies');
    }

    const movies = await response.json() as Movie[];
    // console.log('Loaded movies:', movies);
    return movies;
}
