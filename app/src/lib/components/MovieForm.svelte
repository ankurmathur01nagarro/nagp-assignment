<script lang="ts">
	import type { parseMovie } from "$lib/models/movie";
	import Rating from "./Rating.svelte";

    // Props for the MovieForm component
    type Props = {
        movie: ReturnType<typeof parseMovie>;
        action: string;
    };

    let { movie, action }: Props = $props();
</script>

<form class="imdb-form" {action} method="post">
    <input type="hidden" name="id" bind:value={movie.id} />
    <div class="flex flex-col mb-4">
        <label for="movieTitle">Movie Title:</label>
        <input type="text" id="name" name="name" required class="text-black"
            bind:value={movie.name} />
    </div>
    <div class="flex flex-col mb-4">
        <label for="releaseDate">Release Date:</label>
        <input type="date" id="releaseDate" name="releaseDate" required 
            class="text-black"
            bind:value={
                () => movie.releaseDate.toISOString().split('T')[0],
                (s) => movie.releaseDate = new Date(s)
            } />
    </div>
    <div class="flex flex-col mb-4">
        <label for="rating">Rating (1-10):</label>
        <input type="range" id="rating" name="rating" min="1" max="10" required class="text-black"
            bind:value={movie.rating} />
        <span class="text-gray-500">Current Rating: {movie.rating}</span>
        <Rating rating={movie.rating} />
    </div>
    <div>
        <button type="submit" class="imdb-btn text-sm">Submit</button>
        <a href="/" role="button" class="imdb-btn text-sm"> Cancel </a>
    </div>
</form>