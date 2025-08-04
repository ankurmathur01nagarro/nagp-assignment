<script lang="ts">
	import { goto } from "$app/navigation";
	import MovieForm from "$lib/components/MovieForm.svelte";
	import { type Movie } from "$lib/models/movie";
	import { fail } from "@sveltejs/kit";

    let { data, params } = $props();
	let movie = $state(data.editMovie);

	let editHandler = async (formData: FormData) => {
        const movie: Partial<Movie> = {
            id: +(formData.get('id')?.toString() ?? ""),
            name: formData.get('name') as string,
            releaseDate: formData.get('releaseDate')?.toString(),
            rating: parseInt(formData.get('rating') as string)
        };

        const response = await fetch(`/api/movie`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(movie)
        });

        if (!response.ok) {
            fail(500, { error: 'Failed to update movie' });
        }

        goto('/', {
			invalidateAll: true
		});
    }
</script>

<h1 class="imdb-header">
	<img src="/imdb-logo.svg" alt="IMDB Logo" class="imdb-logo" />
	{movie.name} ({movie.releaseYear})
</h1>
<MovieForm bind:movie={movie} action={editHandler} />