<h1 align="center">🎮 Fuga de la Corona</h1>

<p align="center">
  <i>Proyecto de videojuego de aventura, supervivencia y sigilo — desarrollado en Unity</i>
</p>

---

<h3 align="left">👤 Rol y Participación</h3>

<p align="left">
Fui el único responsable de la <b>programación completa</b> del proyecto, abarcando desde la lógica de IA enemiga hasta la integración de mecánicas de sigilo, interacción, audio y efectos visuales.  
Cada sistema fue diseñado con el objetivo de crear una <b>experiencia inmersiva y dinámica</b>, donde la tensión y el sonido sean parte esencial del gameplay.
</p>

---

<h3 align="left">🧠 Inteligencia Artificial (IA)</h3>

<ul>
  <li>Programación de los <b>estados de comportamiento de los enemigos</b> (patrullaje, persecución, alerta y búsqueda).</li>
  <li>Implementación del sistema de navegación con <b>NavMeshAgent</b> para movimientos fluidos y realistas.</li>
  <li><b>Patrullaje dinámico</b> mediante posiciones aleatorias, evitando patrones repetitivos y que el jugador pueda memorizar sus rutas.</li>
  <li>Cono de visión programable ajustable por dificultad: de <b>45° a 90°</b> según el nivel de reto.</li>
  <li>Sistema auditivo: los enemigos reaccionan a <b>ruidos del jugador</b> si este corre cerca o lanza un objeto (como una botella).</li>
</ul>

---

<h3 align="left">🎮 Mecánicas del Jugador</h3>

<ul>
  <li>Posibilidad de <b>agacharse y esconderse</b> para evitar la detección.</li>
  <li>Recolección y lanzamiento de <b>ítems distractores</b> que emiten sonidos intensos para atraer enemigos a un punto específico.</li>
  <li>Resolución de <b>puzles de platos</b> que otorgan acceso a ítems especiales o pasadizos secretos.</li>
  <li>Sistema de visión tipo <b>Project Zomboid</b>: el jugador solo ve enemigos que están dentro de su campo visual directo, potenciando el sigilo y la tensión.</li>
</ul>

---

<h3 align="left">🎨 Efectos Visuales y Presentación</h3>

<ul>
  <li>Uso de <b>Sprite Mask</b> para efectos visuales de derrota: al perder, se activa un fondo negro y la máscara se contrae, generando un <b>impactante efecto de cierre</b>.</li>
  <li>Implementación de iluminación y sombras que refuerzan la atmósfera de sigilo y peligro constante.</li>
</ul>

---

<h3 align="left">🛠️ Tecnologías Utilizadas</h3>

<ul>
  <li><b>Motor:</b> Unity</li>
  <li><b>Lenguaje:</b> C#</li>
  <li><b>Sistemas:</b> NavMeshAgent, Sprite Mask, Sistema de Detección Visual y Auditiva, Lógica de IA modular</li>
</ul>

---

<h3 align="left">🏆 Concepto General</h3>

<p align="left">
En <b>Fuga de la Corona</b>, el jugador debe escapar de una fortaleza enemiga repleta de bandidos, utilizando el sigilo, el sonido y el ingenio para sobrevivir.  
No hay combate directo: cada paso y cada ruido pueden marcar la diferencia entre escapar... o ser descubierto.
</p>

---

<h3 align="left">📸 Capturas del Proyecto</h3>

<table align="center">
  <tr>
    <td align="center">
      <img src="https://github.com/MiltonCastro93/Fuga_de_la_Corona/blob/main/Captura%20de%20pantalla%202025-11-06%20103030.png" width="300" style="border-radius:10px" alt="Vista general del nivel"/>
      <p><b>Vista general del nivel</b></p>
    </td>
    <td align="center">
      <img src="https://github.com/MiltonCastro93/Fuga_de_la_Corona/blob/main/Captura%20de%20pantalla%202025-11-09%20114432.png" width="300" style="border-radius:10px" alt="SpriteMask"/>
      <p><b>Uso de Sprite Mask</b></p>
    </td>
    <td align="center">
      <img src="https://github.com/MiltonCastro93/Fuga_de_la_Corona/blob/main/Captura%20de%20pantalla%202025-11-09%20114520.png" width="300" style="border-radius:10px" alt="Enemigo"/>
      <p><b>IA enemiga en acción</b></p>
    </td>
  </tr>
</table>

---
