function createChart() {    
    const inputData = document.getElementById('dataInput').value;
    
    
    const data = inputData.split(',').map(Number);
    
    if (data.some(isNaN)) {
      alert("Por favor ingrese solo números válidos separados por comas.");
      return;
    }
    
    
    d3.select('#chart').html('');
  
    
    const width = 600;
    const height = 200;
  
    
    const svg = d3.select('#chart')
                  .append('svg')
                  .attr('width', width)
                  .attr('height', height);
  
    
    const xScale = d3.scaleLinear()
                     .domain([0, d3.max(data)])  // Rango de valores en los datos
                     .range([0, width]);  // Longitud total del gráfico
  
    const yScale = d3.scaleBand()   // El eje Y será un 'scaleBand' para los índices
                     .domain(data.map((d, i) => i))  // Mapeo de los índices
                     .range([0, height])
                     .padding(0.3);  // Espaciado entre las barras
  
   const colors = ['#ff5733', '#33ff57', '#5733ff', '#ff33a8', '#33c1ff'];

    svg.selectAll('rect')
   .data(data)
   .enter()
   .append('rect')
   .attr('x', 0)
   .attr('y', (d, i) => yScale(i))
   .attr('width', d => xScale(d))
   .attr('height', yScale.bandwidth())
   .attr('fill', (d, i) => colors[i % colors.length]); 

  
    // Agregar el texto con la cantidad al final de cada barra
    svg.selectAll('text')
       .data(data)
       .enter()
       .append('text')
       .attr('x', d => xScale(d) + 5)  // Coloca el texto un poco después del final de la barra
       .attr('y', (d, i) => yScale(i) + yScale.bandwidth() / 2)  // Centrar el texto verticalmente en la barra
       .attr('dy', '.35em')  // Ajustar la alineación vertical
       .attr('fill', 'black')  // Color del texto
       .text(d => d);  // Mostrar el valor de la barra
  
  
    svg.append('g')
       .call(d3.axisLeft(yScale));
      
    svg.append('g')
       .attr('transform', `translate(0,${height})`)
       .call(d3.axisBottom(xScale));
  }
  