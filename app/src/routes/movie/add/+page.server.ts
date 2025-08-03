import type { Movie } from "$lib/models/movie";
import { env } from '$env/dynamic/private';
import { fail, redirect } from "@sveltejs/kit";

export let actions = {
    default: async ({ request }) => {
        const formData = await request.formData();
        const movie: Partial<Movie> = {
            id: +(formData.get('id')?.toString() ?? ""),
            name: formData.get('name') as string,
            releaseDate: formData.get('releaseDate')?.toString(),
            rating: parseFloat(formData.get('rating') as string)
        };

        const response = await fetch(`${env.API_BASE_URL}/api/movie`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(movie)
        });

        if (!response.ok) {
            fail(500, { error: 'Failed to add movie' });
            return { status: 500, error: new Error('Failed to add movie') };
        }

        redirect(303, '/');
    }
}