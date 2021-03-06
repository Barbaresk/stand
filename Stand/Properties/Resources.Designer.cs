﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualStand.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VirtualStand.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap buttonBuffer {
            get {
                object obj = ResourceManager.GetObject("buttonBuffer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap checkboxBuffer {
            get {
                object obj = ResourceManager.GetObject("checkboxBuffer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap textboxBuffer {
            get {
                object obj = ResourceManager.GetObject("textboxBuffer", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на library IEEE;
        ///use IEEE.STD_LOGIC_1164.ALL;
        ///use ieee.std_logic_arith.all;
        ///use ieee.std_logic_unsigned.all;.
        /// </summary>
        internal static string vhd0 {
            get {
                return ResourceManager.GetString("vhd0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на 
        ///    Port ( CLK   : in  STD_LOGIC;
        ///           CLR   : in  STD_LOGIC;
        ///           CLR_O : out STD_LOGIC;.
        /// </summary>
        internal static string vhd1 {
            get {
                return ResourceManager.GetString("vhd1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на DATA_IN  : in   STD_LOGIC_VECTOR (63 downto 0);
        ///           DATA_OUT : out  STD_LOGIC_VECTOR (63 downto 0));.
        /// </summary>
        internal static string vhd2 {
            get {
                return ResourceManager.GetString("vhd2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на constant rd   : integer := len - rwc;
        ///	signal value  : std_logic_vector(len - 1 downto 0); --массив для сопоставления
        ///	signal rvalue : std_logic_vector(len - rwc - 1 downto 0);
        ///	type state_type is (
        ///		idle,     --до инициализации 00
        ///		init,     --инициализации    11
        ///		rw,       --чтение/запись    01
        ///		waiting   --ожидание         00
        ///	);
        ///
        ///	
        ///	signal cop   : std_logic_vector(1 downto 0);
        ///	signal arg   : std_logic_vector(15 downto 0);
        ///begin.
        /// </summary>
        internal static string vhd3 {
            get {
                return ResourceManager.GetString("vhd3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на clr_o &lt;= clr;
        ///	value(len - 1 downto rwc) &lt;= rvalue;
        ///	cop &lt;= data_in(1 downto 0);
        ///	arg &lt;= data_in(31 downto 16);
        ///
        ///	process (CLK)
        ///		variable state  : state_type; --состояния элемента
        ///		variable offset : integer;   
        ///		variable endstr : integer;
        ///		variable offr   : integer;
        ///		variable pos    : integer;
        ///		variable i      : integer;
        ///	begin
        ///		if clk = &apos;1&apos; and clk&apos;event then
        ///			if clr = &apos;1&apos; then
        ///				rvalue &lt;= (others =&gt; &apos;0&apos;);
        ///				data_out &lt;= (others =&gt; &apos;0&apos;);
        ///
        ///				state  := idle;
        ///				offset := 0;        /// [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string vhd4 {
            get {
                return ResourceManager.GetString("vhd4", resourceCulture);
            }
        }
    }
}
