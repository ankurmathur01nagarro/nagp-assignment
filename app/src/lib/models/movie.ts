export type Movie = {
    id: number;
    name: string;
    releaseDate: string;
    synopsis: string;
    rating: number;
};

export function parseMovie(data: Movie) {
    return {
        ...data,
        releaseDate: new Date(data.releaseDate),
        releaseDateStr: new Date(data.releaseDate).toDateString(),
        releaseYear: new Date(data.releaseDate).getFullYear(),
        rating: parseInt(data.rating.toString()) // Ensure rating is a float with one decimal
    };
}