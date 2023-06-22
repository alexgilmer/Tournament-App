﻿!function () { const C = document.getElementById("clicker-target"), t = +document.getElementById("data-elem").dataset.maxClicksPerInterval; let e = 0, n = 0, o = !1, l = 0; function r() { document.getElementById("player-score-text").textContent = e; const l = document.getElementById("counter-fill"), r = n > t ? "red" : "deepskyblue"; const a = function (C, t) { return `${Math.min(100, 100 * C / t).toFixed(0)}%` }(n, t); l.style.backgroundColor = r, l.style.width = a, function (t) { t < 0 && (t = 0); t = function (C) { let t = ""; for (; C > 0;) { const e = C % 5; t = e + t, C -= e, C /= 5 } return t }(t), C.textContent = "", C.insertAdjacentHTML("afterbegin", "&oplus;"); const e = ["(", "{", "[", "<"]; for (let n = 0; n < t.length; n++) { const o = n / t.length, l = 3e3 * o, r = 4e3 - l; for (let o = 0; o < t[n]; o++)C.insertAdjacentElement("beforeend", i(e[(t.length - n - 1) % 4], t.length - n, o / t[n], r)) } }(e), e >= 2e4 && !o && (o = !0, function () { let C = "FLAG_butterscotchChips"; C && (C += "1"); const t = document.querySelector("body"); t && (t.textContent = "", t.insertAdjacentHTML("beforeend", '\n            <svg width="651" height="606" xmlns="http://www.w3.org/2000/svg">\n                <defs>.str0 {stroke:black;stroke-width:0.238063}\n                .fil0 {fill:black}\n                .fil2 {fill:#050707}\n                .fil3 {fill:#881846}\n                .fil5 {fill:#F6BCD6}\n                .fil1 {fill:#F9DD56}\n                .fil4 {fill:#FDFCFD}</defs>\n                <g label="Layer 1" id="imagebot_2">\n                <g transform="translate(1.5753, 0.0120087) matrix(1, 0, 0, 1, -89.61, -233.6)" label="Layer 1" id="imagebot_3">\n                <path fill="#000000" d="M569.92,838.8 C562.179,838.561 552.68,838.11 548.809,837.799 C541.519,837.212 538.408,836.422 488.968,822.607 C467.094,816.495 443.986,810.874 433.46,809.105 C429.444,808.43 425.081,807.26 421.875,805.998 C413.56,802.727 390.526,791.011 370.452,779.844 C341.354,763.657 322.74,753.756 306.745,745.958 C283.357,734.555 262.341,721.854 238.916,704.964 C224.29,694.419 216.622,687.865 204.002,675.121 C181.376,652.274 169.008,634.529 158.539,609.891 C150.022,589.849 141.057,575.307 129.005,561.986 C122.821,555.152 115.095,545.256 110.196,537.898 C104.752,529.721 98.346,516.948 95.809,509.21 C90.1952,492.089 88.0347,467.289 90.834,452.102 C93.7738,436.154 102.329,421.77 123.028,397.973 C125.876,394.698 128.332,391.896 128.485,391.747 C129.496,390.766 136.254,382.842 140.877,377.219 C153.305,362.105 160.687,349.742 169.373,329.497 C181.352,301.576 193.516,281.486 209.293,263.559 C217.559,254.168 222.678,249.863 238,239.419 L246.556,233.588 L332.727,233.916 C380.121,234.096 421.821,234.351 425.394,234.483 C428.967,234.615 438.832,234.985 447.317,235.306 C534.767,238.617 588.827,247.905 626.547,266.103 C647.956,276.431 670.789,294.032 681.654,308.583 C687.744,316.739 691.444,326.219 691.444,333.665 C691.444,346.654 695.23,360.688 701.169,369.711 C704.88,375.35 707.569,378.168 713.904,383.058 C725.106,391.706 731.382,401.357 735.041,415.564 C738.069,427.323 739.405,444.181 738.9,464.281 C738.284,488.791 737.719,490.732 719.588,530.59 L710.231,551.159 L710.571,607.725 C710.758,638.836 711.026,667.579 711.167,671.598 C711.308,675.617 711.56,683.534 711.727,689.19 C712.346,710.117 712.812,719.552 714.76,750.487 L715.859,767.939 L710.32,777.823 C698.014,799.78 690.172,808.96 675.242,818.886 C665.401,825.428 649.846,832.671 639.48,835.538 C626.628,839.092 607.893,839.97 569.923,838.797 L569.92,838.8 z M613.224,822.389 C633.451,820.436 640.637,818.711 652.92,812.859 C669.135,805.135 681.288,794.753 690.142,781.061 C692.987,776.662 697.785,766.802 699.35,762.141 C701.099,756.931 701.571,748.655 700.7,738.45 C698.039,707.245 697.481,689.112 696.799,611.79 L696.203,544.128 L705.977,522.626 C722.72,485.793 723.964,481.947 725.048,463.66 C725.945,448.539 724.607,432.227 721.725,423.148 C720.106,418.045 716.748,411.509 713.586,407.307 C712.07,405.293 706.76,399.569 701.785,394.587 C684.504,377.281 679.152,365.899 677.928,343.848 C677.244,331.541 675.065,325.285 668.686,317.324 C658.464,304.566 631.447,285.568 611.864,277.367 C595.109,270.351 580.92,268.416 552.058,269.212 C529.335,269.839 504.928,269.722 494.139,268.934 C481.68,268.023 476.862,267.503 455.977,264.813 C431.889,261.711 418.895,260.401 404.824,259.656 C382.613,258.48 363.619,260.659 345.671,266.441 C317.26,275.593 274.751,299.628 248.912,321.15 C239.42,329.056 232.314,333.908 231.467,333.061 C229.5,331.094 251.619,312.793 278.16,294.427 C299.412,279.721 313.726,272.244 332.744,265.915 C368.195,254.117 404.676,251.78 442.714,258.869 C461.562,262.382 492.672,264.846 525.533,265.43 C543.569,265.75 552.854,265.32 554.066,264.107 C554.793,263.38 551.437,261.657 547.152,260.557 C533.908,257.158 496.855,253.484 459.224,251.839 C455.503,251.677 450.266,251.428 447.586,251.286 C442.125,250.997 428.539,250.564 405.635,249.948 C397.15,249.719 359.257,249.58 321.428,249.637 L252.648,249.742 L243.21,256.124 C232.348,263.469 229.592,265.677 223.145,272.199 C207.667,287.857 194.505,309.49 181.527,340.6 C175.769,354.401 168.579,369.379 165.285,374.431 C164.023,376.366 161.409,379.848 159.477,382.168 C157.544,384.488 156.054,386.467 156.165,386.564 C156.387,386.759 184.041,387.405 192.589,387.415 C195.541,387.419 197.811,387.568 197.632,387.747 C197.453,387.926 191.749,388.66 184.957,389.378 C165.381,391.448 152.187,394.03 145.837,397.035 C134.932,402.194 109.785,437.717 105.765,453.641 C101.324,471.233 104.647,493.916 114.685,514.539 C122.819,531.252 132.753,541.956 145.658,547.919 C150.559,550.183 156.638,554.424 156.638,555.579 C156.638,556.618 154.264,556.42 148.943,554.938 C146.943,554.38 145.141,554.09 144.939,554.293 C144.47,554.762 146.332,557.567 151.49,564.166 C158.319,572.903 166.984,588.7 173.101,603.567 C184.465,631.187 209.668,662.673 236.92,683.298 C256.426,698.06 294.756,721.805 309.825,728.462 C319.945,732.933 349.172,748.473 375.863,763.576 C389.392,771.231 412.141,782.743 421.873,786.859 C426.91,788.99 430.645,790.128 436.488,791.313 C453.783,794.823 470.413,799.23 519.808,813.393 C549.982,822.045 551.709,822.464 560.158,823.172 C568.493,823.87 603.208,823.361 613.222,822.393 z M586.704,769.539 C544.725,768.907 514.687,767.474 496.578,765.239 C443.179,758.649 377.888,741.456 332.838,722.119 C316.214,714.985 285.718,698.507 260.575,683.074 C244.699,673.329 232.427,664.786 232.427,663.478 C232.427,661.274 244.075,667.253 268.965,682.235 C296.57,698.85 304.104,703.118 319.015,710.584 C350.428,726.313 379.209,735.93 431.625,748.212 C482.709,760.182 501.742,762.62 562.345,764.958 C573.956,765.406 586.135,765.892 589.41,766.039 C598.433,766.442 617.38,767.123 618.911,767.098 C619.743,767.085 624.959,763.875 632.443,758.771 C665.836,736 667.201,734.57 668.929,720.553 C669.354,717.102 669.816,714.164 669.956,714.025 C670.417,713.563 670.998,729.898 670.606,732.304 C670.102,735.386 668.011,739.223 665.541,741.595 C663.018,744.019 654.312,750.243 637.946,761.326 L624.957,770.122 L619.363,770.034 C616.286,769.986 601.589,769.763 586.703,769.539 z M532.574,745.952 C516.402,745.704 481.545,744.061 459.499,742.507 C430.408,740.456 417.983,737.445 387.506,725.059 C363.651,715.364 331.526,699.764 299.771,682.454 C286.535,675.238 271.611,666.239 269.028,663.916 C266.841,661.948 266.825,661.908 268.218,661.886 C270.749,661.846 285.967,669.294 308.477,681.591 C330.03,693.365 356.053,706.235 376.999,715.48 C379.801,716.717 391.959,721.814 404.016,726.807 L425.939,735.885 L432.434,736.243 C436.007,736.44 443.192,736.838 448.402,737.128 C468.06,738.222 507.591,740.339 519.312,740.925 C526.011,741.26 540.26,741.545 550.978,741.558 C572.394,741.585 581.744,740.878 591.638,738.482 C605.923,735.023 613.61,730.427 627.03,717.323 C634.712,709.822 638.462,706.792 640.065,706.792 C640.885,706.792 640.957,707.042 640.548,708.468 C638.448,715.791 622.106,730.047 607.256,737.51 C599.255,741.532 590.437,743.636 576.221,744.917 C567.426,745.71 547.53,746.182 532.573,745.953 z M474.655,721.446 L470.866,721.136 L474.929,720.719 C480.17,720.182 531.51,720.175 537.335,720.711 L541.776,721.12 L538.258,721.47 C533.957,721.899 479.933,721.878 474.655,721.446 z M477.091,703.222 C475.453,703.113 469.048,702.77 462.857,702.46 C422.856,700.456 389.501,694.118 362.617,683.413 C335.21,672.5 301.39,649.17 275.71,623.463 C256.145,603.878 244.226,587.888 224.847,555.228 C214.572,537.913 208.185,527.999 204.647,523.873 C201.727,520.468 201.186,518.456 202.165,514.635 C203.133,510.861 202.17,505.316 199.656,500.175 C196.736,494.204 194.284,492.993 185.063,492.972 C174.579,492.948 167.919,490.436 167.576,486.376 C167.435,484.697 167.666,484.229 169.2,483.094 C170.184,482.365 173.425,480.85 176.402,479.725 C183.621,476.999 190.413,473.474 193.724,470.737 C198.743,466.586 200.964,462.463 203.238,453.075 C205.876,442.181 210.929,436.297 214.543,439.911 C215.48,440.848 216.551,443.829 217.473,448.062 C219.887,459.149 252.13,477.478 309.871,500.586 C341.585,513.278 387.945,529.711 409.025,535.733 C434.527,543.018 459.6,547.932 485.484,550.719 C496.572,551.913 531.556,552.09 540.696,550.999 C569.946,547.506 589.582,540.92 608.9,528.122 C627.524,515.784 634.318,504.767 636.751,482.965 C637.083,479.988 637.869,475.039 638.497,471.968 C640.03,464.478 642.029,461.56 645.1,462.331 C647.683,462.979 649.483,467.149 650.772,475.477 C651.613,480.907 653.352,485.203 655.772,487.828 C658.332,490.605 659.576,493.455 661.362,500.64 C668.458,529.182 669.533,591.609 663.548,627.59 C657.161,665.992 641.858,683.509 606.465,692.931 C590.191,697.263 565.081,700.667 536.096,702.47 C526.778,703.05 482.915,703.605 477.094,703.217 z M501.94,685.546 C502.252,683.983 502.739,681.243 503.021,679.456 C503.303,677.67 504.405,671.15 505.468,664.966 C508.165,649.293 508.016,645.447 504.643,643.702 C502.884,642.793 498.123,642.056 488.999,641.281 C479.656,640.488 469.119,638.801 463.108,637.136 C458.727,635.922 457.954,635.84 457.283,636.511 C455.965,637.829 454.983,644.337 454.316,656.18 C453.421,672.078 454.246,684.513 456.298,686.042 C458.099,687.384 469.5,688.191 488.284,688.307 L501.372,688.388 L501.94,685.546 z M537.881,687.015 C541.91,685.784 543.606,683.832 547.609,675.819 C550.382,670.266 558.826,649.633 558.826,648.409 C558.826,647.706 547.846,646.974 537.716,647.001 C525.193,647.035 524.87,647.266 522.062,658.193 C520.859,662.877 516.605,686.243 516.605,688.169 C516.605,688.358 520.685,688.392 525.671,688.244 C532.165,688.051 535.63,687.703 537.88,687.015 z M572.687,682.675 C575.398,681.986 579.118,681.253 580.954,681.045 C582.79,680.837 584.461,680.395 584.669,680.062 C584.876,679.729 585.069,677.508 585.098,675.126 C585.173,668.94 586.32,665.654 595.732,644.638 C596.309,643.351 596.705,642.105 596.614,641.87 C596.522,641.635 593.659,642.263 590.253,643.266 C586.847,644.268 582.474,645.365 580.536,645.702 C576.409,646.421 575.737,647.033 573.195,652.392 C571.409,656.157 563.698,680.954 563.698,682.932 C563.698,684.83 564.269,684.814 572.686,682.675 z M436.467,683.532 C438.049,682.685 439.128,679.127 439.702,672.861 C440.336,665.953 441.628,632.172 441.273,631.817 C441.138,631.682 436.415,630.247 430.778,628.627 C411.773,623.166 402.137,619.69 380.493,610.488 C376.931,608.974 373.986,607.735 373.947,607.735 C373.908,607.735 373.719,611.71 373.527,616.568 C373.061,628.38 371.87,633.007 366.505,643.833 C357.874,661.251 359.18,664.214 378.577,671.223 C401.851,679.633 431.839,686.009 436.466,683.532 z M606.357,675.169 C608.196,674.448 611.453,673.586 613.593,673.254 C615.946,672.889 618.723,671.991 620.615,670.982 C623.784,669.293 630.283,663.839 630.283,662.869 C630.283,662.54 628.856,662.481 626.504,662.712 C623.478,663.01 622.459,662.91 621.388,662.209 C618.619,660.395 618.611,655.893 621.358,645.057 C623.424,636.907 623.092,634.253 620.241,636.121 C616.445,638.609 609.966,649.752 604.959,662.406 C599.079,677.266 599.158,677.99 606.356,675.169 z M637.026,657.351 C640.382,651.623 648.412,630.447 649.442,624.607 C650.933,616.147 638.254,642.344 635.032,654.377 C633.389,660.513 634.341,661.932 637.026,657.351 z M348.936,646.471 C358.52,624.012 360.998,612.001 357.382,605.528 C355.568,602.28 354.169,601.432 346.288,598.809 C336.054,595.402 326.882,591.193 306.508,580.554 L292.643,573.314 L292.344,581.728 C291.939,593.137 290.617,598.019 285.924,605.447 C282.887,610.252 286.101,613.626 314.42,635.356 C321.565,640.838 330.943,648.063 335.26,651.409 C339.576,654.755 343.358,657.502 343.662,657.513 C343.967,657.525 346.34,652.555 348.937,646.47 z M274.147,594.597 C275.158,593.921 276.412,592.52 276.932,591.484 C278.859,587.65 277.717,572.951 275.05,567.253 C272.564,561.941 266.533,557.513 250.752,549.411 C241.116,544.464 236.781,542.559 236.287,543.054 C234.875,544.465 260.077,582.892 269.211,593.255 C270.457,594.669 271.664,595.826 271.893,595.826 C272.121,595.826 273.135,595.273 274.147,594.597 z M454.647,590.277 C454.452,587.225 454.064,581.44 453.784,577.421 C453.504,573.402 453.228,568.84 453.171,567.283 C453.114,565.726 452.928,564.235 452.758,563.969 S451.23,563.22 449.742,562.896 C448.253,562.573 441.798,561.075 435.398,559.567 C391.841,549.31 388.65,548.771 387.229,551.427 C386.524,552.744 383.069,567.532 382.279,572.611 C381.262,579.151 382.417,582.282 386.64,584.436 C389.461,585.875 401.44,589.489 408.875,591.144 C418.912,593.378 430.087,594.814 440.812,595.248 C446.319,595.47 451.766,595.691 452.914,595.738 L455.002,595.824 L454.648,590.276 z M516.049,594.878 C516.046,593.508 513.531,579.47 512.452,574.796 C511.76,571.8 511.256,570.7 510.409,570.344 C509.028,569.762 498.318,568.169 483.573,566.351 C477.47,565.598 471.563,564.837 470.447,564.659 L468.417,564.335 L468.417,580.08 L468.417,595.825 L492.234,595.825 C514.557,595.825 516.051,595.766 516.049,594.878 z M561.52,593.969 C568.948,592.885 576.116,591.12 578.175,589.868 C580.846,588.243 580.8,586.91 577.637,574.412 C575.073,564.281 574.654,563.087 573.692,563.171 C572.131,563.307 527.716,570.504 527.54,570.649 C527.2,570.929 529.136,589.507 529.645,590.845 C530.325,592.635 531.663,594.17 533.102,594.811 C534.705,595.526 554.96,594.925 561.52,593.968 z M602.929,588.789 C603.822,588.536 605.831,588.167 607.394,587.967 C610.518,587.568 611.599,586.548 613.152,582.532 C616.724,573.298 617.438,560.216 614.841,551.583 C613.352,546.634 611.769,546.666 602.387,551.829 C591.092,558.045 590.392,559.297 592.564,569.411 C593.35,573.072 594.237,578.578 594.534,581.647 C595.27,589.246 596.257,590.817 599.635,589.766 C600.553,589.481 602.035,589.041 602.928,588.789 z M636.872,576.552 C637.797,576.073 639.734,574.578 641.175,573.23 C643.579,570.982 643.796,570.57 643.793,568.281 C643.788,564.877 642.199,558.542 639.162,549.816 C635.22,538.487 631.675,531.444 630.505,532.614 C629.094,534.026 628.88,547.649 630.055,561.333 C631.425,577.282 632.184,578.976 636.872,576.552 z M366.042,573.87 C366.641,573.108 367.411,571.098 367.751,569.405 C368.092,567.711 369.297,561.94 370.429,556.582 C372.839,545.177 372.759,544.572 368.483,541.828 C365.766,540.084 358.111,536.881 350.956,534.493 C337.275,529.927 319.821,523.874 309.276,520.036 C295.84,515.147 290.922,514.137 289.895,516.056 C288.899,517.918 288.755,522.167 289.582,525.345 C291.168,531.442 297.526,541.526 304.48,548.973 C309.559,554.411 312.138,556.128 316.681,557.097 C323.56,558.564 328.919,560.653 345.543,568.347 C361.74,575.843 364.009,576.454 366.043,573.87 z M274.973,539.179 C275.959,536.818 276.051,527.521 275.201,515.984 C274.894,511.816 274.641,507.994 274.638,507.49 C274.633,506.518 273.77,505.983 251.628,493.227 C218.765,474.295 210.895,472.042 211.161,481.644 C211.269,485.537 214.639,496.026 217.933,502.722 C221.709,510.398 228.753,516.75 242.697,525.053 C254.213,531.91 271.808,541.118 273.443,541.144 C273.83,541.15 274.518,540.266 274.973,539.18 z M649.853,525.048 C649.002,521.734 645.909,515.594 644.931,515.275 C644.331,515.08 644.246,515.478 644.519,517.191 C645.543,523.59 648.503,529.626 649.923,528.206 C650.348,527.78 650.328,526.9 649.853,525.048 z M162.143,540.597 C160.563,540.036 156.141,537.95 152.315,535.962 C128.406,523.537 124.139,513.65 123.254,468.621 C122.884,449.772 123.463,439.399 125.245,432.968 C127.346,425.387 134.59,412.98 140.516,406.812 C145.919,401.19 152.817,397.727 162.037,396.008 C165.653,395.335 198.121,394.995 206.694,395.541 L211.025,395.816 L203.176,396.529 C198.859,396.92 194.353,397.346 193.162,397.475 C191.971,397.603 185.881,398.207 179.63,398.817 C150.809,401.626 147.583,403.133 137.966,418.281 C133.139,425.884 129.797,432.782 128.392,438.038 C127.361,441.896 127.208,444.205 126.988,459.229 C126.529,490.546 128.823,505.759 135.537,515.922 C139.406,521.779 142.722,524.591 152.836,530.593 C163.958,537.193 167.451,539.793 167.451,541.471 C167.451,541.984 164.833,541.553 162.143,540.598 z M499.453,541.104 C495.141,540.384 490.855,538.574 489.023,536.699 C487.077,534.709 485.192,530.05 485.192,527.232 C485.192,526.146 485.682,524.244 486.282,523.005 C488.215,519.013 491.709,518.428 495.823,521.408 C501.541,525.55 504.294,525.781 510.281,522.626 C516.713,519.237 526.448,507.879 531.819,497.502 C534.421,492.475 534.644,488.719 532.616,484.131 C530.298,478.89 527.206,476.215 522.542,475.415 C516.273,474.341 509.077,463.57 506.576,451.52 C506.087,449.166 505.49,442.809 505.248,437.394 C504.627,423.503 504.324,422.965 493.498,416.53 C487.601,413.026 483.862,409.625 483.258,407.215 C482.669,404.872 483.433,403.214 485.607,402.113 C488.111,400.846 489.653,400.538 495.477,400.143 C504.122,399.557 509.442,397.239 516.787,390.856 C529.971,379.4 539.285,374.98 555.561,372.454 C564.64,371.045 587.09,371.044 593.094,372.452 C600.518,374.193 604.454,376.397 610.755,382.341 C615.137,386.475 617.353,389.841 617.428,392.478 C617.653,400.426 607.121,404.286 575.86,407.709 C541.057,411.52 522.204,417.725 519.895,426.129 C519.16,428.801 519.145,433.728 519.85,440.473 C521.077,452.22 522.781,455.001 533.459,462.687 C545.987,471.705 554.593,479.095 563.89,488.818 C573.569,498.941 577.258,501.783 581.956,502.738 C586.411,503.643 591.246,506.095 595.796,509.755 C599.261,512.542 602.654,516.375 602.654,517.501 C602.654,518.691 599.02,517.516 594.514,514.87 C587.786,510.919 575.107,504.717 570.87,503.303 C564.94,501.325 563.435,501.815 560.123,506.805 C557.589,510.622 556.225,511.015 553.397,508.743 C550.089,506.084 548.732,506.431 543.46,511.281 C540.458,514.042 536.166,518.657 531.516,524.124 C526.635,529.861 519.193,537.062 516.533,538.621 C511.873,541.351 506.025,542.201 499.455,541.103 z M584.438,389.244 C586.716,389.051 588.579,388.707 588.579,388.48 C588.579,387.816 584.368,387.285 579.106,387.285 C573.463,387.286 568.551,387.867 568.551,388.535 C568.551,389.319 578.373,389.757 584.438,389.244 z M400.388,524.134 C397.278,522.356 393.347,519.303 392.06,517.667 C390.023,515.077 387.803,509.452 387.016,504.882 C385.616,496.752 386.876,485.968 389.924,479.993 C393.509,472.966 400.411,469.312 411.154,468.756 C425.051,468.036 432.287,472.597 427.927,479.329 C426.729,481.18 423.838,482.398 418.082,483.477 C403.907,486.135 400.76,488.337 400.76,495.598 C400.76,500.137 402.403,504.216 405.674,507.795 C408.804,511.219 409.966,513.694 409.95,516.9 C409.937,519.376 408.549,522.989 407.025,524.513 C405.725,525.813 403.057,525.661 400.387,524.134 z M157.938,520.104 C156.107,518.973 153.136,515.478 151.364,512.37 C147.377,505.379 144.183,488.715 144.187,474.931 C144.192,457.733 148.675,443.101 157.566,431.26 C160.582,427.244 166.95,421.013 170.868,418.246 C182.57,409.978 207.985,407.129 225.352,412.136 C228.283,412.981 233.144,415.188 238.884,418.28 C254.636,426.763 269.726,432.924 281.283,435.592 C291.19,437.878 299.831,436.571 311.836,430.971 C319.775,427.267 325.461,423.229 331.88,416.74 C338.373,410.175 340.216,409.151 343.802,410.116 C346.994,410.976 347.99,412.395 347.947,416.026 C347.836,425.552 332.206,441.279 316.664,447.502 C299.89,454.219 280.709,453.775 258.496,446.156 C246.028,441.879 227.536,433.122 223.51,429.586 C221.102,427.471 218.888,426.618 213.83,425.856 C206.569,424.762 195.196,426.017 186.944,428.824 C179.688,431.292 176.099,433.98 171.135,440.666 C166.987,446.252 164.061,451.313 161.987,456.493 C156.914,469.163 156.521,474.291 159.631,487.284 C163.543,503.633 164.324,507.813 164.404,512.818 C164.472,517.088 164.324,517.996 163.346,519.314 C161.948,521.198 160.137,521.463 157.937,520.104 z M674.658,518.776 C674.658,517.088 680.683,512.895 693.062,505.968 C708.966,497.069 710.27,495.344 713.925,478.352 C716.368,466.996 717.103,459.999 716.683,452.099 C715.797,435.448 711.451,426.315 701.07,419.283 C697.819,417.081 693.549,413.355 689.002,408.75 C682.108,401.77 679.549,399.893 675.74,399.021 C674.698,398.783 663.98,398.57 651.923,398.549 C631.125,398.512 629.889,398.455 627.835,397.428 C621.645,394.333 628.051,390.43 635.954,392.481 C640.928,393.772 649.978,394.45 662.243,394.45 C680.006,394.451 682.127,395.174 692.407,404.735 C699.52,411.351 705.363,416.222 708.313,417.997 C712.049,420.245 719.951,438.675 721.233,448.131 C722.397,456.714 718.764,480.337 714.088,494.59 C712.707,498.798 711.993,500.126 710.159,501.898 C704.962,506.919 683.715,517.912 676.642,519.238 C675.053,519.536 674.657,519.444 674.657,518.774 z M423.228,518.02 C419.93,517.216 417.986,513.021 418.032,506.802 C418.07,501.633 418.285,500.817 420.147,498.802 C422.686,496.052 425.899,495.401 436.761,495.433 C447.859,495.466 453.793,496.499 460.408,499.547 C467.897,503 469.651,508.104 464.148,510.434 C463.345,510.773 456.832,511.192 448.94,511.411 C440.774,511.637 434.261,512.063 432.992,512.452 C431.807,512.816 429.991,514.026 428.932,515.156 C427.273,516.928 425.019,518.544 424.482,518.346 C424.388,518.312 423.824,518.165 423.228,518.02 z M681.468,494.655 C680.822,493.611 683.213,489.947 688.024,484.609 C696.371,475.347 697.137,473.78 697.033,466.175 C696.955,460.519 695.626,449.548 694.091,441.888 C692.253,432.718 690.039,429.753 681.466,424.979 C675.693,421.764 671.068,417.791 671.572,416.479 C671.765,415.975 672.38,415.564 672.938,415.564 C674.544,415.564 679.959,417.565 684.71,419.914 C692.242,423.639 695.367,427.672 697.383,436.272 C699.809,446.622 701.449,470.119 700.15,475.922 C699.348,479.506 696.356,484.218 692.181,488.472 C687.438,493.305 682.422,496.2 681.468,494.656 z M328.838,487.552 C325.913,486.928 325.531,486.583 326.765,485.68 C328.425,484.466 335.588,483.716 350.158,483.23 C369.111,482.598 375.864,481.164 378.777,477.152 C379.826,475.707 379.827,475.625 378.854,472.761 C377.671,469.281 377.981,468.066 380.048,468.077 C381.856,468.087 382.543,468.498 383.367,470.063 C385,473.165 383.086,479.794 379.667,482.883 C377.208,485.104 375.638,485.59 367.21,486.739 C359.887,487.737 332.432,488.319 328.838,487.552 z M596.988,466.444 C589.031,464.983 585.991,463.775 582.331,460.624 C578.421,457.258 575.984,451.006 577.175,447.396 C579.067,441.663 582.641,441.695 594.163,447.55 C602.455,451.763 604.049,451.488 613.226,444.254 C629.52,431.411 632.672,429.95 645.541,429.281 C660.184,428.519 674.45,432.49 680.936,439.134 C685.299,443.602 686.067,449.397 682.764,452.933 C680.012,455.879 675.141,455.046 668.899,450.561 C658.564,443.136 644.166,442.432 634.786,448.892 C631.338,451.267 628.864,454.569 626.794,459.558 C624.941,464.024 623.052,466.147 620.233,466.929 C616.842,467.871 603.203,467.587 596.988,466.445 z M408.068,427.824 C400.947,423.688 386.865,415.883 383.168,414.025 C359.844,402.301 333.942,399.632 305.739,406.045 C290.93,409.412 281.246,409.049 275.836,404.922 C270.681,400.991 271.552,392.475 278.119,382.597 C289.384,365.652 313.07,355.242 346.09,352.724 C368.529,351.013 387.066,354.935 403.932,364.965 C414.436,371.211 429.538,383.9 433.41,389.734 C437.35,395.671 437.925,401.993 435.059,407.891 C432.614,412.924 420.209,424.467 413.704,427.763 C410.524,429.375 410.734,429.372 408.069,427.824 z M416.871,404.574 C418.215,403.23 418.803,402.154 418.803,401.041 C418.803,397.851 411.553,389.97 403.864,384.803 C391.263,376.334 370.224,366.85 368.301,368.772 C367.66,369.414 364.492,383.963 364.492,386.267 C364.492,388.939 365.972,390.136 369.913,390.654 C375.772,391.425 380.811,393.399 395.394,400.638 C406.397,406.101 408.764,406.948 412.314,406.694 C414.469,406.54 415.282,406.162 416.87,404.574 z M299.771,390.624 C305.533,388.825 309.17,385.72 307.655,383.894 C306.764,382.821 302.099,382.831 298.927,383.912 C294.807,385.315 290.127,390.095 291.189,391.813 C291.633,392.532 295.277,392.027 299.771,390.624 z M255.512,411.413 C255.313,411.215 255.151,410.358 255.151,409.511 C255.151,407.174 257.845,405.666 261.343,406.045 C262.814,406.204 264.359,406.676 264.776,407.094 C265.428,407.745 265.279,408.049 263.724,409.235 C260.841,411.434 256.645,412.547 255.512,411.413 z M243.287,400.629 C239.997,399.745 237.606,398.413 235.739,396.426 C233.196,393.719 235.294,392.108 243.513,390.456 C249.489,389.255 265.532,386.789 265.776,387.034 C265.886,387.144 262.018,388.99 257.18,391.135 C248.525,394.974 245.365,396.756 246.032,397.422 C246.218,397.608 249.062,398.422 252.352,399.231 C255.642,400.04 258.511,400.879 258.727,401.095 C259.467,401.836 246.294,401.438 243.286,400.629 z M512.687,372.468 C512.172,348.851 514.851,336.156 521.024,332.963 C522.762,332.064 524.172,332.472 524.172,333.874 C524.172,334.432 523.067,337.024 521.716,339.635 C518.514,345.822 516.552,353.749 514.713,367.919 C513.922,374.017 513.177,379.104 513.057,379.224 C512.937,379.344 512.77,376.304 512.687,372.467 z M268.697,356.098 C268.697,352.676 279.564,340.413 292.676,329.036 C304.144,319.086 312.134,314.563 326.788,309.725 C338.905,305.725 349.393,303.761 364.236,302.712 C366.617,302.544 370.332,302.268 372.49,302.099 C379.343,301.562 407.323,301.772 413.048,302.404 C421.791,303.369 425.89,305.022 422.058,306.038 C420.083,306.561 408.536,306.585 393.195,306.098 C371.113,305.396 350.981,307.681 332.573,312.98 C314.245,318.255 303.112,325.5 283.312,345.035 C275.729,352.516 270.348,357.097 269.143,357.097 C268.898,357.097 268.697,356.647 268.697,356.098 z M424.937,349.577 C424.251,337.843 421.706,330.753 414.068,319.303 C410.002,313.209 409.016,311.124 409.686,310.039 C410.302,309.042 413.961,311.378 417.106,314.776 C420.702,318.66 424.023,325.233 425.618,331.624 C426.916,336.824 427.034,342.835 426.008,351.414 L425.36,356.827 L424.937,349.578 z M617.317,354.255 C616.739,352.99 615.533,349.509 614.637,346.521 C611.863,337.267 607.722,332.296 596.558,324.818 C588.753,319.59 581.99,316.246 576.956,315.126 C573.46,314.348 571.26,314.238 564.815,314.518 C549.59,315.181 527.631,318.029 516.179,320.827 C508.775,322.635 506.759,322.807 505.849,321.711 C503.27,318.603 513.939,315.359 535.293,312.758 C561.024,309.623 572.97,309.069 579.409,310.711 C583.711,311.808 593.642,316.749 600.136,321.024 C609.14,326.951 615.911,334.611 618.502,341.804 C620.25,346.657 620.521,356.556 618.906,356.556 C618.61,356.556 617.895,355.52 617.317,354.255 z M249.997,350.246 C250.813,346.965 262.496,332.829 269.914,326.148 C291.766,306.465 320.835,290.903 347.009,284.875 C363.035,281.184 377.363,279.643 397.802,279.41 C419.542,279.163 429.103,280.017 447.331,283.836 C467.513,288.065 480.058,289.166 507.956,289.156 C531.557,289.148 538.71,288.747 562.898,286.077 C588.039,283.301 602.328,283.72 608.892,287.426 C611.609,288.96 613.509,291.74 613.509,294.183 C613.509,296.017 613.464,296.056 611.749,295.714 C610.782,295.522 608.36,294.28 606.367,292.956 S601.208,290.026 599.33,289.387 C596.179,288.315 595.187,288.25 586.443,288.539 C581.233,288.712 574.047,289.227 570.475,289.684 C557.247,291.375 539.165,292.722 523.151,293.209 C514.092,293.484 506.519,293.61 506.321,293.488 C506.124,293.365 501.843,293.224 496.809,293.173 C479.687,293.001 461.247,291.027 443.54,287.471 C415.103,281.76 388.081,281.528 361.263,286.764 C323.385,294.159 291.732,310.529 269.047,334.455 C261.931,341.96 253.519,349.73 251.173,350.965 L249.613,351.786 L249.997,350.246 z" id="imagebot_4"/>\n                </g>\n                <title>Layer 1</title>\n                </g>\n            </svg>\n            <h3>I think something broke.  Whoops!<h3>\n            ')); throw new Error("Error code 69420: 3d272de0969a62e69f47816e6a2695c554a310d3626d17e5fe1a4948f1affa9c") }()) } function i(C, t, e, n = 4e3, o = 2, l = !1) { let r = C; for (let C = 0; C < 2 * t; C++)r += "&nbsp;"; o < 2 && (o = 2), rotationSteps = []; for (let C = 0; C <= o; C++) { const t = e + +(C / o).toFixed(2); rotationSteps.push(`rotate(${t}turn)`) } const i = document.createElement("div"); return i.innerHTML = r, i.classList.add("spinner"), i.animate({ transform: rotationSteps, easing: [`${l ? "cubic-bezier(0.95, 0.05, 0.8, 0.04)" : "linear"}`] }, { iterations: 1 / 0, duration: n }), i } function a() { const C = document.getElementById("timer-fill"); C && C.animate({ backgroundColor: ["green", "yellow", "red"], width: ["100%", "0%"], easing: ["linear"] }, 4e3) } C.addEventListener("click", C => { e++, n++, r() }), $(document).on("click", ".buyable-item", C => { !function (C) { const t = +C.dataset.price; if (!t) return; let n = "#cannot-afford"; t <= e && (e -= t, n = "#can-afford"), new bootstrap.Modal(n).show() }(C.target.closest(".buyable-item")) }), r(), a(), setInterval(() => { ++l >= 45 && (l = -1 / 0, new bootstrap.Modal("#bailout-offer").show()), n > t && (e -= n, e -= 100), n = 0, a(), r() }, 4e3) }();