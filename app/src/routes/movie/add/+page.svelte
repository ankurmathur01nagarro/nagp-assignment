<script lang="ts">
	import MovieForm from "$lib/components/MovieForm.svelte";
	import { parseMovie, type Movie } from "$lib/models/movie";
	import { fail } from "@sveltejs/kit";
	import { goto } from "$app/navigation";
    let movie = $state(parseMovie({
		name: '',
		releaseDate: new Date().toISOString(),
		rating: 1,
		synopsis: '',
		id: 0
	}));

	let addhandler = async (formData: FormData) => {
        const movie: Partial<Movie> = {
            id: +(formData.get('id')?.toString() ?? ""),
            name: formData.get('name') as string,
            releaseDate: formData.get('releaseDate')?.toString(),
            rating: parseFloat(formData.get('rating') as string)
        };

        const response = await fetch("/api/movie", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(movie)
        });

        if (!response.ok) {
            fail(500, { error: 'Failed to add movie' });
        }

        goto('/', {
			invalidateAll: true
		});
    }
</script>

<h1 class="imdb-header">
	<img src="/imdb-logo.svg" alt="IMDB Logo" class="imdb-logo" />
	Add New Movie
</h1>
<MovieForm bind:movie={movie} action={addhandler} />