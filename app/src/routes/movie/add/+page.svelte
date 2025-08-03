<script lang="ts">
	import MovieForm from "$lib/components/MovieForm.svelte";
	import { parseMovie, type Movie } from "$lib/models/movie";
    let movie = $state<Movie>({
		name: '',
		releaseDate: new Date().toISOString(),
		rating: 1,
		synopsis: '',
		id: 0
	});

	let parsedMovie = $derived(parseMovie(movie));
</script>

<h1 class="imdb-header">
	<img src="/imdb-logo.svg" alt="IMDB Logo" class="imdb-logo" />
	Add New Movie
</h1>
<MovieForm movie={parsedMovie} action="/movie/add" />