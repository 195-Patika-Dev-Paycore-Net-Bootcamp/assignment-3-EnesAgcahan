toc.dat                                                                                             0000600 0004000 0002000 00000005716 14302760332 0014450 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP       )    (                 z            test1    14.5    14.4     ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         ?           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         ?           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         ?           1262    16427    test1    DATABASE     b   CREATE DATABASE test1 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE test1;
                postgres    false         ?            1259    16433 	   container    TABLE     ?   CREATE TABLE public.container (
    id bigint NOT NULL,
    containername character varying,
    latitude double precision,
    longitude double precision,
    vehicleid bigint
);
    DROP TABLE public.container;
       public         heap    postgres    false         ?            1259    16428    vehicle    TABLE        CREATE TABLE public.vehicle (
    id bigint NOT NULL,
    vehiclename character varying,
    vehicleplate character varying
);
    DROP TABLE public.vehicle;
       public         heap    postgres    false         ?          0    16433 	   container 
   TABLE DATA           V   COPY public.container (id, containername, latitude, longitude, vehicleid) FROM stdin;
    public          postgres    false    210       3312.dat ?          0    16428    vehicle 
   TABLE DATA           @   COPY public.vehicle (id, vehiclename, vehicleplate) FROM stdin;
    public          postgres    false    209       3311.dat `           2606    16439    vehicle vehicle_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.vehicle
    ADD CONSTRAINT vehicle_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.vehicle DROP CONSTRAINT vehicle_pkey;
       public            postgres    false    209         a           1259    16457    fki_container_f    INDEX     J   CREATE INDEX fki_container_f ON public.container USING btree (vehicleid);
 #   DROP INDEX public.fki_container_f;
       public            postgres    false    210         b           1259    16451    fki_containerf    INDEX     I   CREATE INDEX fki_containerf ON public.container USING btree (vehicleid);
 "   DROP INDEX public.fki_containerf;
       public            postgres    false    210         c           2606    16463    container containerf    FK CONSTRAINT     ?   ALTER TABLE ONLY public.container
    ADD CONSTRAINT containerf FOREIGN KEY (vehicleid) REFERENCES public.vehicle(id) ON UPDATE CASCADE ON DELETE CASCADE;
 >   ALTER TABLE ONLY public.container DROP CONSTRAINT containerf;
       public          postgres    false    3168    210    209                                                          3312.dat                                                                                            0000600 0004000 0002000 00000000767 14302760332 0014254 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	container1	10.01	20.02	1
2	container2	10.02	20.02	1
3	container3	10.03	20.02	1
4	container4	10.04	20.02	1
5	container5	10.05	20.02	2
6	container6	10.06	20.02	2
7	container7	10.07	20.02	2
9	container9	10.09	20.02	1
10	container10	10.1	20.02	1
11	container11	10.11	20.02	1
12	container12	10.12	20.02	1
13	container13	10.13	20.02	2
15	container15	10.15	20.02	2
16	container16	10.16	20.02	2
17	container17	10.17	20.02	2
8	container8	10.08	20.02	1
18	asdasdasd	20.2	20.2	1
19	newCOntainer	20.2	30.3	2
\.


         3311.dat                                                                                            0000600 0004000 0002000 00000000100 14302760332 0014230 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	vehicle	12ab123
2	vehicle2	12abc123
3	newVehicle	12asd50
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                restore.sql                                                                                         0000600 0004000 0002000 00000006013 14302760332 0015364 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 14.5
-- Dumped by pg_dump version 14.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE test1;
--
-- Name: test1; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE test1 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';


ALTER DATABASE test1 OWNER TO postgres;

\connect test1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: container; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.container (
    id bigint NOT NULL,
    containername character varying,
    latitude double precision,
    longitude double precision,
    vehicleid bigint
);


ALTER TABLE public.container OWNER TO postgres;

--
-- Name: vehicle; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.vehicle (
    id bigint NOT NULL,
    vehiclename character varying,
    vehicleplate character varying
);


ALTER TABLE public.vehicle OWNER TO postgres;

--
-- Data for Name: container; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.container (id, containername, latitude, longitude, vehicleid) FROM stdin;
\.
COPY public.container (id, containername, latitude, longitude, vehicleid) FROM '$$PATH$$/3312.dat';

--
-- Data for Name: vehicle; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.vehicle (id, vehiclename, vehicleplate) FROM stdin;
\.
COPY public.vehicle (id, vehiclename, vehicleplate) FROM '$$PATH$$/3311.dat';

--
-- Name: vehicle vehicle_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vehicle
    ADD CONSTRAINT vehicle_pkey PRIMARY KEY (id);


--
-- Name: fki_container_f; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_container_f ON public.container USING btree (vehicleid);


--
-- Name: fki_containerf; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_containerf ON public.container USING btree (vehicleid);


--
-- Name: container containerf; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.container
    ADD CONSTRAINT containerf FOREIGN KEY (vehicleid) REFERENCES public.vehicle(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     