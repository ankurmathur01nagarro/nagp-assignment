import { parseMovie, type Movie } from "$lib/models/movie";
import { env } from '$env/dynamic/public';

export async function load({ params }) {
    const movieId = +params.movieId;
    const response = await fetch(`${env.PUBLIC_API_BASE_URL}/api/movie/${movieId}`);
    if (!response.ok) {
        throw new Error('Failed to fetch movie details');
    }
    const movie = await response.json() as Movie;
    return {
        editMovie: parseMovie(movie)
    };
}
