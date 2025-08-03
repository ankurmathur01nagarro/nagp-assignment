<script lang="ts">
    import Rating from '$lib/components/Rating.svelte';
    let { data } = $props();
</script>

<h1 class="imdb-header">
  <img src="/imdb-logo.svg" alt="IMDB Logo" class="imdb-logo" />
  Movies
</h1>
<ul class="movie-list">
  {#each data.movies as movie (movie.id)}
    <li class="movie-list-item relative h-12">
      <a href="/movie/{movie.id}" class="text-lg font-semibold text-yellow-300 hover:text-yellow-200 absolute inset-0 flex items-center justify-between px-4">
        <span>{movie.name} ({movie.releaseYear})</span>
        <Rating rating={movie.rating} />
      </a>
    </li>
  {/each}
</ul>
<a href="/movie/add" role="button" class="imdb-btn text-sm">
  + Add Movie
</a>