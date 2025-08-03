<script lang="ts">
	import '../app.tailwind.css';

	let { children } = $props();
</script>


<div class="min-h-screen bg-gray-900 text-gray-100 py-8 px-4">
  <div class="max-w-3xl mx-auto">
	  {@render children()}
  </div>
</div>
