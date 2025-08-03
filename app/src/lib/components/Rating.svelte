<script lang="ts">
    let { rating } = $props<{ rating: number }>();
    
    // Convert 1-10 rating to 0-5 scale
    let scaledRating = $derived(rating / 2);
    
    type StarType = {
        isFullStar: boolean;
        isHalfStar: boolean;
    };

    let stars = $derived<StarType[]>(
        [1, 2, 3, 4, 5].map((index) => {
            const diff = scaledRating - index;
            const isFullStar = diff >= 0;
            const isHalfStar = !isFullStar && diff > -1 && diff <= 0;

            return {
                isFullStar,
                isHalfStar
            };
        })
    );
</script>

<span class="flex items-center">
    {#each stars as star}
        <svg 
            class="w-5 h-5 {star?.isFullStar 
                ? 'text-yellow-300' 
                : star?.isHalfStar 
                    ? 'text-yellow-300/50' 
                    : 'text-gray-500'}" 
            xmlns="http://www.w3.org/2000/svg" 
            viewBox="0 0 24 24" 
            fill="currentColor"
        >
            <path d="M12 2L15.09 8.26L22 9.27L17 14.14L18.18 21.02L12 17.77L5.82 21.02L7 14.14L2 9.27L8.91 8.26L12 2Z" />
        </svg>
    {/each}
</span>
