<script lang="ts">
	import MovieForm from "$lib/components/MovieForm.svelte";

    let { data, params } = $props();
	let movie = $state(data.editMovie);
</script>

<h1 class="imdb-header">
	<img src="/imdb-logo.svg" alt="IMDB Logo" class="imdb-logo" />
	{movie.name} ({movie.releaseYear})
</h1>
<MovieForm {movie} action="/movie/{params.movieId}" />